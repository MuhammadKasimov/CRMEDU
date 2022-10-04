using CRMEDU.Api.Exceptions;
using log4net;

namespace CRMEDU.Api.Midleware
{
    public class ExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        ILog _log;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _log = LogManager.GetLogger(typeof(ExceptionHandlingMiddleware));
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (MyCustomException ex)
            {
                await httpContext.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                await httpContext.Response.WriteAsJsonAsync(ex.Message);
                _logger.LogError(ex.ToString());
            }
        }



    }
}
