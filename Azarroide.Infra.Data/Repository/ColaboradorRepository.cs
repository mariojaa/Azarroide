using Azarroide.Domain.Entities;
using Azarroide.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Azarroide.Infra.Data.Repository
{
    public class ColaboradorRepository : IColaborador
    {
        public Task<ActionResult<ColaboradorEntitie>> BuscarIdColaborador(int id)
        {
            var sessaoColaborador = new EmpresaEntitie
            {
                Id = id,
            };
            return null;
        }
    }
}
