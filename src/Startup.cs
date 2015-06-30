using System.Linq;
using Microsoft.AspNet.Mvc;
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
			services.AddMvc().Configure<MvcOptions>(options =>
			{
				options.OutputFormatters
					.Where(f => f is JsonOutputFormatter)
					.Select(f => f as JsonOutputFormatter)
					.First()
					.SerializerSettings
					.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});
			
			services.AddEntityFramework().AddNpgsql();
		}
		
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseErrorPage();
			
			//app.UseStatusCodePages();
            app.UseFileServer();
			
			app.UseMvc();
		}
	}
}