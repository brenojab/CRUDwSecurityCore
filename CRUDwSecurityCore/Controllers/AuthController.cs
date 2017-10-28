using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRUDwSecurityCore.Controllers
{
  public class AuthController : Controller
  {
    public IActionResult Login()
    {
      if (User.Identity.IsAuthenticated)
      {
        return RedirectToAction("Usuarios", "App");
      }

      return View();
    }

    public IActionResult Logoff()
    {

      return RedirectToAction("Index", "Login");
    }

  }
}