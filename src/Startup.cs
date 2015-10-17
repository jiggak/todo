using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
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
      
      public void Configure(IApplicationBuilder app)
      {
         app.UseDeveloperExceptionPage();
         
         //app.UseStatusCodePages();
         app.UseFileServer();
         
         app.UseMvc();
      }
   }
}