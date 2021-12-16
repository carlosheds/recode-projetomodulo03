using Microsoft.AspNetCore.Mvc;

namespace AgenciaViagemUp.Controllers
{
    public class PromocoesController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}