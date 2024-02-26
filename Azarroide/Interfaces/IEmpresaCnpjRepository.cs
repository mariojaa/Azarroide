using Azarroide.Domain.Entities;

namespace Azarroide.Repository.Interface
{
    public interface IEmpresaCnpjRepository
    {
        List<EmpresaEntitie> ListarTodasEmpresasCadastradas();
        EmpresaEntitie BuscarEmpresaPorId(int id);
        void AdicionarNovaEmpresa(EmpresaEntitie empresaEntitie);
        EmpresaEntitie AtualizarDadosDaEmpresa(EmpresaEntitie empresaEntitie, int id);
        void DeletarEmpresa(int id);
        EmpresaEntitie BuscarEmpresaPorNome(string nome);
        EmpresaEntitie BuscarEmpresaPorCnpj(string cnpj);
    }
}