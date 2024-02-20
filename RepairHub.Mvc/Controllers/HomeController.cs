using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepairHub.Mvc.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
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
        public async Task<IActionResult> SignIn(dynamic user)
        {
            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                    new(ClaimTypes.Name, "Bob"),
                    new(ClaimTypes.NameIdentifier, "1"),
                    new(ClaimTypes.Authentication, "vffhshiuflvhksfjl")
            }, CookieAuthenticationDefaults.AuthenticationScheme)),
            new AuthenticationProperties() { IsPersistent = true });
            return Redirect("/");

            //, new JwtSecurityTokenHandler()
            //.ReadJwtToken(response)
            //.Claims.FirstOrDefault(claim => claim.Type == "nameid")?.Value
        }

        [AllowAnonymous]
        public IActionResult SignUp() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(dynamic user)
        {
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
