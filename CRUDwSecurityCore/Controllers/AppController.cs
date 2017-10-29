using Microsoft.AspNetCore.Mvc;

namespace CRUDwSecurityCore.Controllers
{
  public class AppController : Controller
  {
    public AppController()
    {
    
    }

    public IActionResult Index()
    {
      return View();
    }

    
  }
}