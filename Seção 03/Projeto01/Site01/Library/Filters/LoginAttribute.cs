using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Verificar session
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                if (context.Controller != null)
                {
                    Controller controller = context.Controller as Controller;
                    controller.TempData["ErrorMessage"] = "Do the login";
                }
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            // Redirecionar
            /*base.OnActionExecuting(context);*/
        }
    }
}
