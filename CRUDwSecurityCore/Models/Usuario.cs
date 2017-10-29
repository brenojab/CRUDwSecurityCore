using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDwSecurityCore.Models
{
  public class Usuario
  {
    [Key]
    public Guid Guid { get; set; }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public bool Administrador { get; set; }

    public string CodUsuario { get; set; }

    public string Senha { get; set; }

    public string Email { get; set; }

  }
}
