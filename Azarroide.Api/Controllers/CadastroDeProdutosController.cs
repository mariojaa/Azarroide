using Microsoft.AspNetCore.Mvc;

namespace AzaRRoide.API.Controllers
{
    [Route("api/cadastro-de-produtos")]
    [ApiController]
    public class CadastroDeProdutosController : ControllerBase
    {
        private readonly ICadastroDeProdutos _cadastroDeProdutos;

        public CadastroDeProdutosController(ICadastroDeProdutos cadastroDeProdutos)
        {
            _cadastroDeProdutos = cadastroDeProdutos;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroDeProdutosEntitie>>> MostrarProdutosCadastrados()
        {
            try
            {
                var produtosCadastrados = await _cadastroDeProdutos.ObterTodosOsProdutosCadastrados();
                return Ok(produtosCadastrados);
            }
            catch (Exception)
            {
                return StatusCode(500, "Sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CadastroDeProdutosEntitie>> CadastrarNovoProduto(CadastroDeProdutosEntitie cadastroDeProdutos)
        {
            try
            {
                if (cadastroDeProdutos.ColaboradorCadastroProduto != null)
                {
                    //obter nome abreviado colaborador
                    cadastroDeProdutos.ColaboradorCadastroProduto.NomeEUltimoNomeColaborador = ObterNomeAbreviadoColaborador(cadastroDeProdutos.ColaboradorCadastroProduto.NomeEUltimoNomeColaborador);
                }

                var novoProduto = await _cadastroDeProdutos.AdicionarNovoProdutoCadastrado(cadastroDeProdutos);
                return Ok(novoProduto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente!");
            }
        }

        // obter o nome abreviado do colaborador
        private string ObterNomeAbreviadoColaborador(string nomeCompleto)
        {
            string[] partesNome = nomeCompleto.Split(' ');
            if (partesNome.Length >= 2)
            {
                return partesNome[0] + " " + partesNome[partesNome.Length - 1].Substring(partesNome[partesNome.Length - 1].Length - 1);
            }
            return nomeCompleto;
        }
    }
}
