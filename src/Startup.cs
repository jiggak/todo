using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace TodoApp
{
   public class Startup
    {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc().AddJsonOptions(options =>
         {
            options.SerializerSettings.ContractResolver =
                  new CamelCasePropertyNamesContractResolver();
         });

         services.AddLogging();

         //services.AddEntityFramework().AddNpgsql();
         //services.AddEntityFramework().AddSqlite();
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
      {
         app.UseDeveloperExceptionPage();
         app.UseDefaultFiles();
         app.UseStaticFiles();
         app.UseMvc();
      }

      public static void Main(string[] args)
      {
         var host = new WebHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .UseKestrel()
            .Build();
         
         host.Run();
      }
   }
}