using AutoMapper;
using Azarroide.Domain.Entities;
using Azarroide.Infra.Data.Context;
using Azarroide.Models;
using Azarroide.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IEmpresaCnpjRepository _empresaCnpjRepository;
        private readonly string API_ENDPOINT = "https://receitaws.com.br/v1/cnpj/";
        private readonly IMapper _mapper;
        private readonly EmpresaDbContextApi _context;

        public EmpresaController(IEmpresaCnpjRepository empresaCnpjRepository, IMapper mapper, EmpresaDbContextApi context)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(API_ENDPOINT)
            };
            _empresaCnpjRepository = empresaCnpjRepository;
            _mapper = mapper;
            _context = context;
        }

        // Método para listar todas as empresas cadastradas
        public IActionResult ListarTodasEmpresasCadastradas()
        {
            List<EmpresaEntitie> empresas = _empresaCnpjRepository.ListarTodasEmpresasCadastradas();

            return View(empresas);
        }

        // Método para buscar uma empresa por ID
        [HttpGet]
        public IActionResult BuscarEmpresaPorId()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarEmpresaPorId(int id)
        {
            EmpresaEntitie empresa = _empresaCnpjRepository.BuscarEmpresaPorId(id);

            return View(empresa);
        }

        // Método para adicionar uma nova empresa
        [HttpGet]
        public IActionResult AdicionarNovaEmpresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarNovaEmpresa(EmpresaEntitie empresaEntitie)
        {
            _empresaCnpjRepository.AdicionarNovaEmpresa(empresaEntitie);

            return RedirectToAction("BuscarempresaPorCnpj");
        }

        // Método para atualizar os dados de uma empresa
        [HttpGet]
        public IActionResult AtualizarDadosDaEmpresa(int id)
        {
            EmpresaEntitie empresa = _empresaCnpjRepository.BuscarEmpresaPorId(id);

            return View(empresa);
        }

        [HttpPost]
        public IActionResult AtualizarDadosDaEmpresa(EmpresaEntitie empresaEntitie, int id)
        {
            _empresaCnpjRepository.AtualizarDadosDaEmpresa(empresaEntitie, id);

            return RedirectToAction("ListarTodasEmpresasCadastradas");
        }

        // Método para deletar uma empresa
        [HttpGet]
        public IActionResult DeletarEmpresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeletarEmpresa(int id)
        {
            _empresaCnpjRepository.DeletarEmpresa(id);

            return RedirectToAction("ListarTodasEmpresasCadastradas");
        }

        // Método para buscar uma empresa por nome
        [HttpGet]
        public IActionResult BuscarEmpresaPorNome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarEmpresaPorNome(string nome)
        {
            EmpresaEntitie empresa = _empresaCnpjRepository.BuscarEmpresaPorNome(nome);

            return View(empresa);
        }

        // Método para buscar uma empresa por CNPJ
        [HttpGet]
        public IActionResult BuscarEmpresaPorCnpj()
        {
            return View();
        }
        //04206050000180
        public async Task<IActionResult> BuscarEmpresaPorCnpj(string cnpj)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{API_ENDPOINT}{cnpj}");

                if (response.IsSuccessStatusCode)
                {
                    var viaEmpresaResponse = await response.Content.ReadFromJsonAsync<EmpresaEntitie>();

                    if (viaEmpresaResponse != null)
                    {
                        return View(viaEmpresaResponse);
                    }
                    else
                    {
                        return NotFound(); // CNPJ não encontrado na API
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor: " + ex.Message);
            }
        }
        private bool EmpresaExistenteNoBancoDeDados(string cnpj) //Verifica se existe cadastro no banco
        {
            return _context.EmpresaEntitie.Any(p => p.cnpj == cnpj);
        }
        [HttpGet]
        public async Task<IActionResult> Detalhes(string cnpj, EmpresaEntitie empresaEntitie) //Salva no Banco de dados
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{API_ENDPOINT}{cnpj}");

                if (response.IsSuccessStatusCode)
                {
                    var viaEmpresaResponse = await response.Content.ReadFromJsonAsync<EmpresaEntitie>();
                    empresaEntitie = viaEmpresaResponse;
                    viaEmpresaResponse = _mapper.Map<EmpresaEntitie>(empresaEntitie);

                    if (EmpresaExistenteNoBancoDeDados(empresaEntitie.cnpj)) //Verifica se existe cadastro no banco
                    {
                        return RedirectToAction("ListarTodasEmpresasCadastradas", "Empresa");
                    }
                    else
                    {
                        _empresaCnpjRepository.AdicionarNovaEmpresa(empresaEntitie);
                        return View(viaEmpresaResponse);
                    }

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor: " + ex.Message);
            }
        }
    }
}