using Azarroide.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Azarroide.Infra.Data.Interfaces
{
    public interface IColaborador
    {
        Task<ActionResult<ColaboradorEntitie>> BuscarIdColaborador(int id);
    }
}
