using Azarroide.Data;
using Azarroide.Models;
using Azarroide.Repository.Interface;

namespace Azarroide.Repository
{
    public class EmpresaCnpjRepository : IEmpresaCnpjRepository
    {
        private readonly AzarroideDbContext _context;
        public EmpresaCnpjRepository(AzarroideDbContext context)
        {
            _context = context;
        }

        public void AdicionarNovaEmpresa(EmpresaModel empresaModel)
        {
            _context.Empresa.Add(empresaModel);
            _context.SaveChanges();
        }

        public EmpresaModel AtualizarDadosDaEmpresa(EmpresaModel empresaModel, int id)
        {
            EmpresaModel empresaPorId = BuscarEmpresaPorId(id);
            if (empresaModel == null)
            {
                throw new Exception($"Empresa com Id {id}, não encontrada na base de dados do sistema local!");
            }
            empresaPorId.nome = empresaPorId.nome;
            empresaPorId.email = empresaPorId.email;
            empresaPorId.telefone = empresaPorId.telefone;

            _context.Empresa.Update(empresaPorId);
            _context.SaveChanges();
            return empresaPorId;
        }

        public EmpresaModel BuscarEmpresaPorId(int id)
        {
            return _context.Empresa.FirstOrDefault(x => x.Id == id);
        }

        public EmpresaModel BuscarEmpresaPorCnpj(string cnpj)
        {
            return _context.Empresa.FirstOrDefault(x => x.cnpj == cnpj);
        }

        public EmpresaModel BuscarEmpresaPorNome(string nome)
        {
            return _context.Empresa.FirstOrDefault(x => x.nome == nome);
        }

        public void DeletarEmpresa(int id)
        {
            var empresa = BuscarEmpresaPorId(id);
            if (empresa != null)
            {
                _context.Empresa.Remove(empresa);
                _context.SaveChanges();
            }
        }

        public List<EmpresaModel> ListarTodasEmpresasCadastradas()
        {
            return _context.Empresa.ToList();
        }
    }
}
