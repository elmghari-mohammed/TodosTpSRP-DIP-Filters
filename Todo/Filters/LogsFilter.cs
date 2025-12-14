using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Text;

namespace Todo.Filters
{
    public class LogsFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                // Récupérer le nom du contrôleur et de l'action
                string controllerName = "";
                string actionName = "";

                if (context.ActionDescriptor is ControllerActionDescriptor controllerAction)
                {
                    controllerName = controllerAction.ControllerName;
                    actionName = controllerAction.ActionName;
                }

                // Récupérer le login user depuis la session
                var session = context.HttpContext.Session;
                string loginUser = "Non authentifié";

                // Vérifier si authentifié
                var userValue = session.GetString("username");
                if (!string.IsNullOrEmpty(userValue))
                {
                    loginUser = userValue;
                }

                // Date/heure pour le message
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Date pour le nom du fichier (fichier par jour)
                string dateForFileName = DateTime.Now.ToString("yyyy-MM-dd");

                // Créer le message de log
                string logMessage = $"{timestamp} - {loginUser} - {controllerName} - {actionName}\n";

                // CHEMIN AVEC DOSSIER Logs
                string logsDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

                // Créer le dossier Logs s'il n'existe pas
                if (!Directory.Exists(logsDir))
                {
                    Directory.CreateDirectory(logsDir);
                }

                // Chemin du fichier de log (par jour)
                string logPath = Path.Combine(logsDir, $"logs-{dateForFileName}.txt");

                // Écrire dans le fichier
                File.AppendAllText(logPath, logMessage, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // Ne pas casser l'application en cas d'erreur de log
                Console.WriteLine($"Erreur de logging: {ex.Message}");
            }

            base.OnActionExecuted(context);
        }
    }
}