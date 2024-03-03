using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairHub.Domain.Requests;
using RepairHub.Mvc.Infrastructure.Queries.GetData;
using RepairHub.Mvc.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace RepairHub.Mvc.Controllers
{
    [Authorize]
    public class HomeController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;
        public IActionResult Index() => View();

        [AllowAnonymous]
        public IActionResult SignIn() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserRequest request)
        {
            try
            {
                var response = await _mediator.Send(new AuthenticationQuery(request.Login, request.HashPassword));
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                        new(ClaimTypes.Name, request.Login),
                        new(ClaimTypes.NameIdentifier, response.Id.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties() { IsPersistent = true });
            }
            catch (ValidationException ex)
            {
                foreach(var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
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
