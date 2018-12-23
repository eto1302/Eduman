using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Eduman.Middlewares.MiddlewaresExtensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}