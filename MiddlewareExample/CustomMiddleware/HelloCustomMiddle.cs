﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareExample.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HelloCustomMiddle
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddle(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //before logic
            if(httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
            {
                string fullname = httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastname"];
                await httpContext.Response.WriteAsync(fullname);
            }
            await _next(httpContext);

            //after logic

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloCustomMiddleExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddle>();
        }
    }
}
