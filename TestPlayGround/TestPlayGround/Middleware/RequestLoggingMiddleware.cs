namespace TestPlayGround.Middleware
{
    public class RequestLoggingMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context,RequestDelegate next)
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            // Custom header нэмэх
            context.Response.Headers.Add("My-Custom-Header", "ErdenebatsDemo");
            await next(context);
        }
    }
}
