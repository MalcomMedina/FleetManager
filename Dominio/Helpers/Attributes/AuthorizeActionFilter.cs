using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Dominio.Helpers.Attributes
{
    public class AuthorizeActionFilter: IActionFilter
    {
        //props
        private readonly ILogger<AuthorizeActionFilter> logger;

        public AuthorizeActionFilter(ILogger<AuthorizeActionFilter> Logger)
        {
            logger = Logger;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            string Controller = context.Controller.ToString();
            string Action = context.ActionDescriptor.ToString();
            string HttpContext = context.HttpContext.ToString();
            logger.LogError("OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogError("OnActionExecuted");
        }
    }
}
