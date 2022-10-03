using Microsoft.AspNetCore.Mvc;

namespace YUEX.OrderManagementProject.API.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
