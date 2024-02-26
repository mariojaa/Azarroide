using Azarroide.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzaRRoide.Infra.Data.Context
{
    public class EmpresaDbContextApi : DbContext
    {
        public EmpresaDbContextApi(DbContextOptions<EmpresaDbContextApi> options) : base(options)
        {

        }
        //public DbSet<EmpresaEntitie> EmpresaEntitie { get; set; }
        public DbSet<CadastroDeProdutosEntitie> CadastroDeProdutos { get; set; }
    }
}
