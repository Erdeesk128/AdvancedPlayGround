using TestPlayGround.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddTransient<RequestLoggingMiddleware>();
builder.Services.AddTransient<IpRestrictedMiddleware>();
var app = builder.Build();
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapRazorPages();
app.Run();
