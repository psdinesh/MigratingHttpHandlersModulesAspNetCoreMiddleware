using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewareForHttpHandlersModules
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomHanlderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomHanlderMiddleware>();
        }
        public static IApplicationBuilder UseCustomModuleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomModuleMiddleware>();
        }
        public static IApplicationBuilder UseSessionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionMiddleware>();
        }
    }
}
