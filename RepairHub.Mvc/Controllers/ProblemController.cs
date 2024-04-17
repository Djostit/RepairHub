using Microsoft.AspNetCore.Mvc;

namespace RepairHub.Mvc.Controllers
{
    public class ProblemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
