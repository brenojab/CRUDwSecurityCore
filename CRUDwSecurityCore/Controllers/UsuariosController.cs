using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDwSecurityCore.Interfaces;
using AutoMapper;
using CRUDwSecurityCore.ViewModels;
using CRUDwSecurityCore.Models;
using Microsoft.Extensions.Configuration;

namespace CRUDwSecurityCore.Controllers
{
  [Route("usuarios")]
  public class UsuariosController : Controller
  {
    private IUsuarioRepository _repository { get; set; }
    private IConfigurationRoot _config;
    private UsuarioContext _context;

    public UsuariosController(IConfigurationRoot config, IUsuarioRepository repository, UsuarioContext context)
    {
      _repository = repository;
      _config = config;
      _context = context;
    }

    //public IActionResult Index()
    //{
    //  var data = _context.Usuarios.ToList();

    //  return View(data);
    //}

    //[Authorize]
    public IActionResult Get()
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

    [HttpGet("Index")]
    public IActionResult Index()
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

      //try
      //{
      //  var usuarios = _repository.GetAllUsuarios();

      //  return View(Mapper.Map<IEnumerable<UsuariosViewModel>>(usuarios));
      //}
      //catch (Exception ex)
      //{
      //  return BadRequest("Erro ao obter usuários");
      //}
    }

    [HttpGet("Create")]
    public IActionResult Create(Guid guid)
    {
      var usuario = _repository.GetUsuarioById(guid);

      return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UsuariosViewModel usuarioVM)
    {
      var usuario = Mapper.Map<Usuario>(usuarioVM);
      _repository.AddUsuario(usuario);

      if (await _repository.SaveChangesAsync())
      {
        return Created($"api/usuarios/{usuarioVM.Nome}", Mapper.Map<Usuario>(usuario));
      }

      return BadRequest("Usuário não criado");

    }
  }
}