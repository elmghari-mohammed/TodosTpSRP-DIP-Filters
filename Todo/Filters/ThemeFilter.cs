
using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Filters
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Récupérer le thème depuis le cookie
            var themeCookie = context.HttpContext.Request.Cookies["theme"];
            var theme = themeCookie ?? "light";

            // Envoyer le thème au ViewBag via HttpContext.Items
            context.HttpContext.Items["Theme"] = theme;

            base.OnActionExecuting(context);
        }
    }
}