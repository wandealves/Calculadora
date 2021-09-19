using System;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Calculadora.Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.BadRequest;

            var ex = context.Exception;
            var msg = "Internal error has occurred.";

            context.Result = JsonResult(ex, message: msg, statusCode);
            context.HttpContext.Response.StatusCode = (int)statusCode;
        }

        protected JsonResult JsonResult(Exception ex, string message = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new JsonResult(new
            {
                Status = statusCode,
                IsValid = true,
                Error = message
            });
        }

        protected bool ExceptionOfType(Exception ex, Type expect)
        {
            if (ex != null && ex.GetType() == expect)
                return true;

            if (ex.InnerException != null)
                return ExceptionOfType(ex.InnerException, expect);

            return false;
        }
        
        protected TException GetExceptionOfType<TException>(Exception ex) where TException : class
        {
            if (ex != null && ex.GetType() == typeof(TException))
                return ex as TException;

            if (ex.InnerException != null)
                return GetExceptionOfType<TException>(ex.InnerException);

            return null;
        }
    }
}
