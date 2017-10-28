using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CRUDwSecurityCore.Interfaces;
using Microsoft.Extensions.Configuration;
using CRUDwSecurityCore.Models;

namespace CRUDwSecurityCore.Controllers
{
  public class AppController : Controller
  {
    private IUsuarioRepository _repository;
    private IConfigurationRoot _config;
    private UsuarioContext _context;

    public AppController(IConfigurationRoot config, IUsuarioRepository repository, UsuarioContext context)
    {
      _repository = repository;
      _config = config;
      _context = context;
    }

    public IActionResult Index()
    {
      var data = _context.Usuarios.ToList();

      return View(data);
    }

    [Authorize]
    public IActionResult Usuarios()
    {
      try
      {
        var usuarios = _repository.GetAllUsuarios();

        return View(usuarios);
      }
      catch (Exception ex)
      {
        return BadRequest("Não foi possível retornar os usuários.");
      }
    }
  }
}