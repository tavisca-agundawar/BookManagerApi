using Microsoft.AspNetCore.Http;
using log4net;
using WebApiTraining.Controllers;
using System.Threading.Tasks;

namespace WebApiTraining.Middleware
{
    public class LoggerMiddleware
    {
        private RequestDelegate _next;
        private static readonly ILog log = LogManager.GetLogger(typeof(BookController));

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            log.Info("******\nRequest from client:\n" + context.Request.Scheme + context.Request.Host.ToUriComponent() + "\n******");

            try
            {
                await _next(context);
            }
            catch
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Error occured while processing request! Please try again.");
            }

            log.Info("******\nResponse from Server:\n" + context.Response.StatusCode +"\t"+ context.Response + "\n******");
        }
    }
}
