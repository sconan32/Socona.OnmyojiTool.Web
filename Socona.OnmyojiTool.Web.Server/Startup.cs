using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace Socona.OnmyojiTool.Web.Server
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddDbContext<Repository.Sql.SqlOnmyojiToolContext>(options =>
            {                         
                options.UseSqlServer(Configuration.GetConnectionString("TargetConnectionString"));
            });
            services.AddSingleton<Repository.IOnmyojiToolRepository, Repository.Sql.SqlOnmyojiToolRepository>(sv =>
            {             
                var dbOptions = new DbContextOptionsBuilder<Repository.Sql.SqlOnmyojiToolContext>().UseSqlServer(
                    Configuration.GetConnectionString("TargetConnectionString"));
                return new Repository.Sql.SqlOnmyojiToolRepository(dbOptions);
            });

        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
