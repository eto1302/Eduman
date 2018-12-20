using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Eduman.Middlewares.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}