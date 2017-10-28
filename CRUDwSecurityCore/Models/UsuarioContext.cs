using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDwSecurityCore.Models
{
  public class UsuarioContext : /*DbContext*/ IdentityDbContext<LoginUser>
  {
    public DbSet<Usuario> Usuarios { get; set; }

    private IConfigurationRoot _config;

    public UsuarioContext()
    {

    }

    public UsuarioContext(DbContextOptions options, IConfigurationRoot config) : base(options)
    {
      _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      //// TODO: Implementação da comunicação com o banco de dados.
      //optionsBuilder.UseSqlServer(_config["ConnectionStrings:ContextConnection"]);
    }
  }
}
