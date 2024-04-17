using Microsoft.AspNetCore.Mvc;

namespace RepairHub.Mvc.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
