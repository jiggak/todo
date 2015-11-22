using Microsoft.AspNet.Builder;
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

         services.AddEntityFramework().AddNpgsql();
      }

      public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
      {
         //loggerFactory.AddConsole();

         app.UseDeveloperExceptionPage();

         app.UseStatusCodePages();

         app.UseFileServer();

         app.UseMvc();
      }
   }
}