using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewareForHttpHandlersModules
{
    public class CustomHanlderMiddleware
    {
        private RequestDelegate _next;

        public CustomHanlderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<h2>This handler is written for processing files with srini extension<h2>");

            //more logic follows...
        }
    }
}
