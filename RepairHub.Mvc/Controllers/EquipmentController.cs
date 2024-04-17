using Microsoft.AspNetCore.Mvc;

namespace RepairHub.Mvc.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
