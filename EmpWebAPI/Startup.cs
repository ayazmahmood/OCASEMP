using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpWebAPI.Models;
using EmpWebAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmpWebAPI
{
    public class Startup
    {
        private IConfiguration config;
        public Startup(IConfiguration _config)
        {
            config = _config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false); //In Core 3 we need to pass this way).

            //Connection String
            services.AddDbContext<EmpDBContext>(options =>
            options.UseSqlServer(
                config["EMP:ConectionString"]
                ));
            services.AddCors();
            services.AddTransient<EmpRepository>();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
            app.UseDeveloperExceptionPage(); //To Show Exception on page.. Once Final Please remark this page. Ayaz
            //app.UseOpenApi();
            app.UseAuthentication(); // Telling out Website/app that this site may use authentication scheme... As in this case we are using JWT.
            // app.UseAuthorization(); // This shall call always after app.useAuthentication.
            app.UseMvc(); // To Add MVC Pattren in our App
        }
    }
}
