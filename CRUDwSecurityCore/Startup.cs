using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CRUDwSecurityCore.Models;
using AutoMapper;
using CRUDwSecurityCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using CRUDwSecurityCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUDwSecurityCore
{
  public class Startup
  {
    private IHostingEnvironment _env;
    private IConfigurationRoot _config;

    //public Startup(IConfiguration configuration)
    //{
    //  Configuration = configuration;
    //}

    public Startup(IHostingEnvironment env)
    {
      _env = env;
      var builder = new ConfigurationBuilder()
        .SetBasePath(_env.ContentRootPath)
         .AddJsonFile("config.json") // adiciona informações da base de dados
        .AddEnvironmentVariables();
      _config = builder.Build();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // TODO: Estudar SAPORRA toda
      services.AddSingleton(_config);

      services.AddEntityFrameworkSqlServer().AddDbContext<UsuarioContext>(config =>
      {
        // TODO: Implementação da comunicação com o banco de dados.
        config.UseSqlServer(_config["ConnectionStrings:ContextConnection"]);
      });

      services.AddTransient<UsuariosContextSeedData>();

      services.AddIdentity<LoginUser, IdentityRole>(config =>
      {
        config.User.RequireUniqueEmail = true;
        config.Password.RequiredLength = 8;
      }).AddEntityFrameworkStores<UsuarioContext>();

      services.AddScoped<IUsuarioRepository, UsuarioRepository>();


      services.AddMvc();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, UsuariosContextSeedData seeder, ILoggerFactory logger)
    {

      Mapper.Initialize(config =>
      {
        config.CreateMap<UsuariosViewModel, Usuario>().ReverseMap();
      });


      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        logger.AddDebug(LogLevel.Information);
      }
      else
      {
        logger.AddDebug(LogLevel.Error);
      }


      app.UseDefaultFiles();

      app.UseStaticFiles();
      app.UseAuthentication();

      app.UseMvc(config =>
      {
        config.MapRoute(
          name: "Default",
          template: "{controller}/{action}/{id?}",
          defaults: new { controller = "App", action = "Index" }
          );
      });

      seeder.Seed().Wait(); // TODO: Só pode executar o SEED caso a base tenha sido criada. Por isso que é preciso COMENTAR isso ANTES de executar o Add-migration
    }
  }
}
