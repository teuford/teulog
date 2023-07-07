using Microsoft.AspNetCore.Builder;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
await using WebApplication application = builder.Build();

application.MapGet("/", () => "Hello World!");

await application.RunAsync();
