using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Softplan.Financial.Commom.Types;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Softplan.Financial.Commom.Middlewares
{
    public class SoftplanErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public SoftplanErrorHandlerMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext contexto)
        {
            try
            {
                await _next(contexto);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(contexto, ex);
            }
        }

        private static Task HandleErrorAsync(HttpContext contexto, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var codeError = "ServerError";
            var message = "Houve um erro ao processar a solicitação";

            switch (exception)
            {
                case SoftException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    codeError = ex.Code;
                    message = ex.MessageError;
                    break;
            }

            var response = new { code = codeError, message };
            var payload = JsonConvert.SerializeObject(response);

            contexto.Response.ContentType = "application/json";
            contexto.Response.StatusCode = (int)statusCode;

            return contexto.Response.WriteAsync(payload);
        }
    }
}
