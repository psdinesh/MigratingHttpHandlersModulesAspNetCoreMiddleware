using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewareForHttpHandlersModules
{
    public class SessionMiddleware
    {
        private RequestDelegate _nextRequestDelegate;

        public SessionMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            //Passing the data.
            context.Items["Username"] = "srini";

            // Using Sessions
            var sessionValue = context.Session.GetString("mySessionValue");
            await context.Response.WriteAsync("The session value in custom middleware is " + sessionValue);
            context.Session.SetString("mySessionValue", "modified!!!</br>");

            await context.Response.WriteAsync("My session middleware started handling the request!!! </br>");
            await _nextRequestDelegate.Invoke(context);
            await context.Response.WriteAsync("My session middleware ended handling the request!!! </br>");
        }
    }
}
