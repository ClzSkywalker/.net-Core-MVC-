using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreStudy.Serivce;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCoreStudy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<ICinemaService, CinemaMemoryService>();
            services.AddSingleton<IMovieService, MovieMemoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //显示错误
            //app.UseStatusCodePages();

            //添加自定义错误
            //app.UseStatusCodePagesWithRedirects();

            //加载wwwroot文件夹下css,js
            app.UseStaticFiles();

            app.UseMvc(routes =>
                {
                    //默认路由：没有指定url和controller情况下会默认找到下面这个
                    routes.MapRoute(
                        name: "default", 
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
