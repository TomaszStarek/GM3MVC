using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial.Exceptions;

namespace tutorial.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFoundExceptions)
            {
                context.Response.StatusCode = 404;
                // await context.Response.WriteAsync(notFoundExceptions.Message);
                context.Response.Redirect("/Error/NotFounded");
            }
            catch (UnauthorizedException unauthorizedException)
            {
                context.Response.StatusCode = 401;
                //  await context.Response.WriteAsync(unauthorizedException.Message);
                context.Response.Redirect("/Error/Unauthorize");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
               // await context.Response.WriteAsync("Something went wrong");
                context.Response.Redirect("/Error");

            }
        }
    }
}
