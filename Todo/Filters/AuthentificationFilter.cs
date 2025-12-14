using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Filters
{
    public class AuthentificationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (context.HttpContext.Session.GetString("authentifie") == null)
            {
                // Rediriger vers Users/Index (login)
                context.Result = new RedirectToActionResult("Login", "Users", null);
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Pas d'action nécessaire après l'exécution

        }

    }
}
    