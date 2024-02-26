using Azarroide.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Azarroide.Infra.Data.Interfaces
{
    public interface ICadastroDeProdutos
    {
        Task<IEnumerable<CadastroDeProdutosEntitie>> ObterTodosOsProdutosCadastrados();
        Task<ActionResult<CadastroDeProdutosEntitie>> AdicionarNovoProdutoCadastrado(CadastroDeProdutosEntitie cadastroDeProdutos);
        Task DeletarProdutoCadastrado (int id);
        Task<ActionResult<CadastroDeProdutosEntitie>> BuscarProdutoCadastradoPorId(int id);
        Task AtualizarProdutoCadastrado(CadastroDeProdutosEntitie cadastroDeProdutos);
    }
}
