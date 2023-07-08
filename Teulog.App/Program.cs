using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Teulog.App;

const string connectionStringName = "TeulogDb";

WebApplicationBuilder applicationBuilder = WebApplication.CreateBuilder(args);
IServiceCollection services = applicationBuilder.Services;
services.AddDbContext<TeulogDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(applicationBuilder.Configuration.GetConnectionString(connectionStringName)
        ?? throw new InvalidOperationException($"Connection string '{connectionStringName}' not found.")));
services.AddRazorPages();

await using WebApplication application = applicationBuilder.Build();
application.MapRazorPages();

await application.RunAsync();
