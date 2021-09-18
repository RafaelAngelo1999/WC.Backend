using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using WC.BackEnd.Model;
using WC.Shared.Exceptions;

namespace WC.BackEnd.Util
{
    public static class GlobalExceptionHandlerExtension
    {
        public static void UseCustomErrors(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<GlobalExceptionHandler>(loggerFactory);
        }
    }

    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public GlobalExceptionHandler(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<GlobalExceptionHandler>();
        }

        public async Task Invoke(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception == null) return;

            ErroModel erro;

            switch (exception)
            {
                case ParametroInvalidoException ex:
                    context.Response.StatusCode = 400;
                    erro = new ErroModel(ex);
                    break;
                case PermissaoNegadaException ex:
                    context.Response.StatusCode = 401;
                    erro = new ErroModel(ex);
                    break;
                case AplicacaoException ex:
                    context.Response.StatusCode = 500;
                    erro = new ErroModel(ex);
                    logger.LogError(exception, "Projeto Padrão - Falha na aplicação.");
                    break;
                default:
                    context.Response.StatusCode = 500;
                    erro = new ErroModel("Erro ao executar operação.", exception);
                    logger.LogError(exception, "Projeto Padrão - Falha Inesperada.");
                    break;
            }

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var json = JsonConvert.SerializeObject(erro, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            await context.Response.WriteAsync(json);

            await this.next(context);
        }
    }
}
