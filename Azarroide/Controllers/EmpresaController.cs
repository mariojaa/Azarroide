using Microsoft.AspNetCore.Mvc;

namespace Azarroide.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
