using Microsoft.AspNetCore.Mvc;

namespace YUEX.OrderManagenetProject.API.Controllers
{

    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
