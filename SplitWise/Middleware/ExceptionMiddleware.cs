using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SplitWise.API.Middleware.Models;
using SplitWise.BusinessLogic.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SplitWise.API.Middleware
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(EntityNotFoundException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogError($"Error entity not found by key = [{ex._entityKey}]: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
            catch(ArgumentIsNotUniqueException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                _logger.LogError($"Not allow error: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
            catch(Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Error: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
