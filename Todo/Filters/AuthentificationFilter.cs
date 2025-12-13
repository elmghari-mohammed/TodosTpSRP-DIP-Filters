using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Filters
{
    public class AuthentificationFilter : Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.HttpContext.Session.GetString("authentifie") == null)
            {
                // Rediriger vers Users/Index (login)
                context.Result = new RedirectToActionResult("Login", "Users", null);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Pas d'action nécessaire après l'exécution

        }
    }
}
    