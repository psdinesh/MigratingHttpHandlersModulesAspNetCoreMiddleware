using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewareForHttpHandlersModules
{
    public class CustomModuleMiddleware
    {
        private RequestDelegate _next;
        public CustomModuleMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<h3>Custom module started the begin request</h3>");

            await _next.Invoke(context);

            await context.Response.WriteAsync("<h3>Custom module completed the request</h3>");
        }
    }
}
