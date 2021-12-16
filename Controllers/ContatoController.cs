using Microsoft.AspNetCore.Mvc;

namespace AgenciaViagemUp.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}