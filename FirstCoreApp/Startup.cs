using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FirstCoreApp
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method get called by the runtime. Use this method to add services to the containers.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookContext>
                (
                    options => options.UseSqlServer(config.GetConnectionString("bookConnection"))
                );

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<BookContext>();

            services.AddMvc();
            services.AddTransient<IBookRepository, BookRepository>();
            //services.AddSingleton<IBookRepository, MockBookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseStatusCodePages();
                //app.UseStatusCodePagesWithRedirects("/CustomError/{0}");
                app.UseStatusCodePagesWithReExecute("/CustomError/{0}");
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
