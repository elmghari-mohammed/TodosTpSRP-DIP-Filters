using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
