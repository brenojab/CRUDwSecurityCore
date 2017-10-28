using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwSecurityCore.Models
{
  public class UsuariosContextSeedData
  {
    public UsuarioContext _context { get; set; }

    public UsuariosContextSeedData(UsuarioContext context)
    {
      _context = context;
    }


    public async Task Seed()
    {
      if (!_context.Usuarios.Any())
      {
        var usuario = new Usuario()
        {
          Guid = new Guid("90a17e45-4d25-49e2-8bb5-581d64b0dedc"),
          Nome = "Breno",
          Sobrenome = "Batista",
          Administrador = true,
          CodUsuario = "brenojab",
          DataNascimento = new DateTime(2017, 09, 07),
          Email = "brenojab@gmail.com",
          Senha = "123",
          Sexo = "M"
        };

        _context.Usuarios.Add(usuario);

        await _context.SaveChangesAsync();
      }
    }
  }
}
