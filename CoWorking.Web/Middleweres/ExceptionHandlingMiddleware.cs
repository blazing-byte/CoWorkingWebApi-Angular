﻿using CoWorking.Contracts.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace CoWorking.Web.Middleweres
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException ex)
            {
                await CreateErrorAsync(context, ex.StatusCode, new { error = ex.Message });
                return;
            }
            catch (Exception)
            {
                await CreateErrorAsync(context);
                return;
            }        
        }

        private async Task CreateErrorAsync(
           HttpContext context,
           HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
           object errorBody = null)
        {
            // does nothing
            _ = errorBody ?? new { error = "Unknown error has occured" };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorBody));
        }
    }
}
