using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Context;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Behavior;
using RepairHub.Mvc.Infrastructure.Services;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;
using RepairHub.Mvc.Middleware;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddAuthorization();

services.AddControllersWithViews();

services.AddDbContext<RepairHubContext>(opt =>
{
    //#if DEBUG
    //    opt.UseInMemoryDatabase("repair");
    //#else
    opt
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseSnakeCaseNamingConvention();
    //#endif
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
    .AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
builder.Services.AddMapster();
TypeAdapterConfig<User, UserDto>.NewConfig()
    .Map(dst => dst.Role, src => src.Role.Name);
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true);


var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

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