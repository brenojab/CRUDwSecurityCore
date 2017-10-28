using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwSecurityCore.ViewModels
{
  public class UsuariosViewModel
  {
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Nome { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
  }
}
