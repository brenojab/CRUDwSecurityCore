using CRUDwSecurityCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDwSecurityCore.Models
{
  public class UsuarioRepository : IUsuarioRepository
  {
    public UsuarioContext _context { get; set; }

    public UsuarioRepository(UsuarioContext context)
    {
      _context = context;
    }

    public void AddUsuario(Usuario usuario)
    {
      _context.Add(usuario);
    }

    public IEnumerable<Usuario> GetAllUsuarios()
    {
      return _context.Usuarios.ToList();
    }

    public Usuario GetUsuarioById(Guid guid)
    {
      return _context.Usuarios.Where(u => u.Guid == guid).FirstOrDefault() ;
    }

    public async Task<bool> SaveChangesAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }
  }
}
