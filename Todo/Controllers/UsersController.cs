using Microsoft.AspNetCore.Mvc;
using Todo.Filters;
using Todo.ViewModels;

namespace Todo.Controllers
{

    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Retourne login.cshtml
        }

        public IActionResult Login()
        {
            return View(); // Retourne login.cshtml
        }

        [HttpPost]
        public IActionResult Login(UserLoginVM vm) // POST avec UserLoginVM
        {
            if (!ModelState.IsValid)
            {
                // Si validation échoue (champs vides), retourne la vue avec erreurs
                return View(vm);
            }

            // Vérifier les identifiants
            if (vm.Username == "admin" && vm.Password == "admin")
            {
                HttpContext.Session.SetString("authentifie", "");
                HttpContext.Session.SetString("username", vm.Username);
                return RedirectToAction("Index", "Todos");
            }
            else
            {
                // Identifiants incorrects
                ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe incorrect");
                return View(vm);
            }
        }
        [AuthentificationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("authentifie");
            return RedirectToAction(nameof(Login));
        }
    }
}