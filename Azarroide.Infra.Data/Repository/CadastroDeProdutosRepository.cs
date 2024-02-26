using Azarroide.Domain.Entities;
using Azarroide.Infra.Data.Context;
using Azarroide.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Azarroide.Infra.Data.Repository
{
    public class CadastroDeProdutosRepository : ICadastroDeProdutos
    {
        private readonly EmpresaDbContextApi _context;
        public CadastroDeProdutosRepository(EmpresaDbContextApi context)
        {
            _context = context;
        }
        public async Task<ActionResult<CadastroDeProdutosEntitie>> AdicionarNovoProdutoCadastrado(CadastroDeProdutosEntitie cadastroDeProdutos)
        {
            _context.CadastroDeProdutos.Add(cadastroDeProdutos);
            await _context.SaveChangesAsync();
            return cadastroDeProdutos;
        }

        public async Task AtualizarProdutoCadastrado(CadastroDeProdutosEntitie cadastroDeProdutos)
        {
            _context.Entry(cadastroDeProdutos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<CadastroDeProdutosEntitie>> BuscarProdutoCadastradoPorId(int id)
        {
            return await _context.CadastroDeProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeletarProdutoCadastrado(int id)
        {
            var cadastroDeProduto = await BuscarProdutoCadastradoPorId(id);
            if (cadastroDeProduto != null)
            {
                _context.CadastroDeProdutos.Remove(cadastroDeProduto.Value);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CadastroDeProdutosEntitie>> ObterTodosOsProdutosCadastrados()
        {
            return await _context.CadastroDeProdutos.ToListAsync();
        }
    }
}
