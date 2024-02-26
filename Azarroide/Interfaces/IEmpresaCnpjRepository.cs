using Azarroide.Models;

namespace Azarroide.Repository.Interface
{
    public interface IEmpresaCnpjRepository
    {
        List<EmpresaModel> ListarTodasEmpresasCadastradas();
        EmpresaModel BuscarEmpresaPorId(int id);
        void AdicionarNovaEmpresa(EmpresaModel empresaModel);
        EmpresaModel AtualizarDadosDaEmpresa(EmpresaModel empresaModel, int id);
        void DeletarEmpresa(int id);
        EmpresaModel BuscarEmpresaPorNome(string nome);
        EmpresaModel BuscarEmpresaPorCnpj(string cnpj);
    }
}
