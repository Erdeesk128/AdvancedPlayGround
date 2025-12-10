
namespace TestPlayGround.Middleware
{
    public class IpRestrictedMiddleware : IMiddleware
    {
        private readonly ILogger<IpRestrictedMiddleware> _logger;
        private readonly List<string>? _allowedIps;
        private readonly IWebHostEnvironment _env;
        public IpRestrictedMiddleware(ILogger<IpRestrictedMiddleware> logger,IWebHostEnvironment env)
        {
            _env= env;  
            _logger = logger;
            string textfilepath = Path.Combine(_env.WebRootPath, "TxtFiles", "AuthorizedIpLists.txt");
            if (File.Exists(textfilepath))
            {
                _allowedIps = System.IO.File.ReadAllLines(textfilepath).ToList();
            }
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var remoteip = context.Connection.RemoteIpAddress?.ToString();
            _logger.LogInformation($"Incoming request from IP:{remoteip}");
            if(!_allowedIps.Contains(remoteip))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access denied:Your IP address is not authorized");
                return;
            }
            await next(context);
        }
    }
}
