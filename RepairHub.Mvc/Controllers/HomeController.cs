using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Domain.Requests;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;
using RepairHub.Mvc.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepairHub.Mvc.Controllers
{
    [Authorize]
    public class HomeController(IEntityService<User> service, IMapper mapper) : Controller
    {
        private readonly IEntityService<User> _service = service;
        private readonly IMapper _mapper = mapper;
        public IActionResult Index() => RedirectToAction(nameof(Index), "Application");

        [AllowAnonymous]
        public IActionResult SignIn() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserRequest request)
        {
            try
            {
                var response = _mapper.Map<UserDto>(await _service.Items.FirstAsync(x => x.Login == request.Login));
                if(response is null || !BCrypt.Net.BCrypt.Verify(request.HashPassword, response.HashPassword))
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                    return View(request);
                }
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(
                [
                        new(ClaimTypes.Name, request.Login),
                        new(ClaimTypes.NameIdentifier, response.Id.ToString()),
                        new(ClaimTypes.Role, response.RoleId.ToString())
                ], CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties() { IsPersistent = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View(request);
            }

            return Redirect("/");
        }


        public IActionResult Privacy() => View();

        [AllowAnonymous]
        public IActionResult AccessDenied() => View();

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
