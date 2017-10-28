using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDwSecurityCore.Interfaces;
using AutoMapper;
using CRUDwSecurityCore.ViewModels;
using CRUDwSecurityCore.Models;

namespace CRUDwSecurityCore.Controllers
{
  [Route("api/[controller]")]
  public class UsuariosController : Controller
  {
    private IUsuarioRepository _repository { get; set; }

    public UsuariosController(IUsuarioRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        var usuarios = _repository.GetAllUsuarios();

        return View(Mapper.Map<IEnumerable<UsuariosViewModel>>(usuarios));
      }
      catch (Exception ex)
      {
        return BadRequest("Erro ao obter usuários");
      }
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