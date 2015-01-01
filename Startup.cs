using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Routing;
using Microsoft.Data.Entity;
using Microsoft.Framework.Cache.Memory;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using VNext.Models;

namespace KWebStartup
{
  public class Startup
  {
    public Startup()
    {
      Configuration = new Configuration()
                  .AddJsonFile("config.json")
                  .AddEnvironmentVariables(); //All environment variables in the process's context flow in as configuration values.
    }

    public IConfiguration Configuration { get; private set; }

    // This method gets called by the runtime.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add EF services to the services container.
        services.AddEntityFramework(Configuration)
                .AddDbContext<VNextContext>();

        // Add MVC services to the services container.
        services.AddMvc();
    }

    //This method is invoked when ASPNET_ENV is 'Development' or is not defined
    //The allowed values are Development,Staging and Production
    public void ConfigureDevelopment(IApplicationBuilder app)
    {
      //Display custom error page in production when error occurs
      //During development use the ErrorPage middleware to display error information in the browser
      app.UseErrorPage(ErrorPageOptions.ShowAll);  
      app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);

      // Add the runtime information page that can be used by developers
      // to see what packages are used by the application
      // default path is: /runtimeinfo
      app.UseRuntimeInfoPage();

      Configure(app);
    }

    // Configure is called after ConfigureServices is called.
    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();

      // Add MVC to the request pipeline
      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "{controller}/{action}/{id?}",
            defaults: new { controller = "Home", action = "Index" });

        routes.MapRoute(
            name: "api",
            template: "{controller}/{id?}");
      });
    }
  }
}