﻿using Microsoft.AspNetCore.Mvc;

namespace RepairHub.Mvc.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}