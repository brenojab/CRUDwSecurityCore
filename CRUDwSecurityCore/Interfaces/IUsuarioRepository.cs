using CRUDwSecurityCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwSecurityCore.Interfaces
{
  public interface IUsuarioRepository
  {
    IEnumerable<Usuario> GetAllUsuarios();
    void AddUsuario(Usuario usuario);
    Task<bool> SaveChangesAsync();
    Usuario GetUsuarioById(Guid guid);
  }
}
