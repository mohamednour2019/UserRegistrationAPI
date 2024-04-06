using Microsoft.AspNetCore.HttpLogging;
using RegistrationWebApplication.Core.Domain.RepositoriesContracts;
using RegistrationWebApplication.Core.Services;
using RegistrationWebApplication.Core.ServicesContracts;
using RegistrationWebApplication.Infrastructure.ApplicationContext;
using RegistrationWebApplication.Infrastructure.Repositories;
using RegistrationWebApplication.Presentation.API.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>();

builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider srvice, LoggerConfiguration logger) =>
{
    logger.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(srvice);
});


builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestProperties |
    HttpLoggingFields.ResponsePropertiesAndHeaders;
});
builder.Services.AddScoped<IAddUserService, AddUserService>();
builder.Services.AddScoped<IGetDateService, GetDateService>();
builder.Services.AddScoped<IGetUserByNameService, GetUserByNameService>();
builder.Services.AddScoped<IGetUserSortedService, GetUserSortedService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
var app = builder.Build();
app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseExceptionHandlingMiddleware();

}
app.UseRouting();
app.MapControllers();
app.Run();
