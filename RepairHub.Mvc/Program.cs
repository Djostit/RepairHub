using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Context;
using RepairHub.Mvc.Behavior;
using RepairHub.Mvc.Infrastructure.Extensions;
using RepairHub.Mvc.Infrastructure.Services;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;
using RepairHub.Mvc.Middleware;
using RepairHub.Mvc.Models;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddAuthorization();

services.AddControllersWithViews();

services.AddDbContext<RepairHubContext>(opt =>
{
#if DEBUG
    opt.UseInMemoryDatabase("repairhub");
#else
opt
.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
.UseSnakeCaseNamingConvention();
#endif
});

services.AddRouting(x =>
{
    x.LowercaseQueryStrings = true;
    x.LowercaseUrls = true;
});

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/home/signin";
        options.LogoutPath = "/home/signout";
        options.AccessDeniedPath = "/home/accessdenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        //options.Cookie.Name = Guid.NewGuid().ToString();
    });

services.AddHostedService<DatabaseInit>()
    .AddScoped(typeof(IEntityService<>), typeof(EntityService<>))
    .AddScoped<ITokenService, TokenService>();
services.ConfigureJwtAuthentication(builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>());
services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<Program>());
services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationPipelineBehavior<,>)));
services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true);

var app = builder.Build();

//app.UseMiddleware<ErrorHandlingMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();