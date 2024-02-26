using Azarroide.Models;
using Microsoft.EntityFrameworkCore;

namespace Azarroide.Data
{
    public class AzarroideDbContext : DbContext
    {
        public AzarroideDbContext(DbContextOptions<AzarroideDbContext> options) : base(options)
        {
        }
        public DbSet<EmpresaModel> Empresa { get; set; }
        public DbSet<Azarroide.ViewModel.EmpresaViewModel>? EmpresaViewModel { get; set; }
    }
}
