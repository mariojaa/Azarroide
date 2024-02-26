using Azarroide.Domain.Entities;
using Azarroide.Infra.Data.Context;
using Azarroide.Models;
using Azarroide.Repository.Interface;

namespace Azarroide.Repository
{
    public class EmpresaCnpjRepository : IEmpresaCnpjRepository
    {
        private readonly EmpresaDbContextApi _context;
        public EmpresaCnpjRepository(EmpresaDbContextApi context)
        {
            _context = context;
        }

        public void AdicionarNovaEmpresa(EmpresaEntitie empresaEntitie)
        {
            _context.EmpresaEntitie.Add(empresaEntitie);
            _context.SaveChanges();
        }

        public EmpresaEntitie AtualizarDadosDaEmpresa(EmpresaEntitie empresaEntitie, int id)
        {
            EmpresaEntitie empresaPorId = BuscarEmpresaPorId(id);
            if (empresaEntitie == null)
            {
                throw new Exception($"Empresa com Id {id}, não encontrada na base de dados do sistema local!");
            }
            empresaPorId.nome = empresaPorId.nome;
            empresaPorId.email = empresaPorId.email;
            empresaPorId.telefone = empresaPorId.telefone;

            _context.EmpresaEntitie.Update(empresaPorId);
            _context.SaveChanges();
            return empresaPorId;
        }

        public EmpresaEntitie BuscarEmpresaPorId(int id)
        {
            return _context.EmpresaEntitie.FirstOrDefault(x => x.Id == id);
        }

        public EmpresaEntitie BuscarEmpresaPorCnpj(string cnpj)
        {
            return _context.EmpresaEntitie.FirstOrDefault(x => x.cnpj == cnpj);
        }

        public EmpresaEntitie BuscarEmpresaPorNome(string nome)
        {
            return _context.EmpresaEntitie.FirstOrDefault(x => x.nome == nome);
        }

        public void DeletarEmpresa(int id)
        {
            var empresa = BuscarEmpresaPorId(id);
            if (empresa != null)
            {
                _context.EmpresaEntitie.Remove(empresa);
                _context.SaveChanges();
            }
        }

        public List<EmpresaEntitie> ListarTodasEmpresasCadastradas()
        {
            return _context.EmpresaEntitie.ToList();
        }
    }
}
