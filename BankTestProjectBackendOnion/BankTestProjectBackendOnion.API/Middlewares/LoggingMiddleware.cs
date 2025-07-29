namespace BankTestProjectBackendOnion.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var endpointName = endpoint?.DisplayName ?? "Unknown endpoint";

            _logger.LogInformation("Received request for endpoint: {Endpoint} at {Time}", endpointName, DateTime.Now);

            await _next(context); // call the next middleware

            _logger.LogInformation("Response sent from endpoint: {Endpoint} at {Time}", endpointName, DateTime.Now);
        }
    }

}
