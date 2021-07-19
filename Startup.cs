using ApiPracticas.Context;
using ApiPracticas.Interface;
using ApiPracticas.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ApiPracticas
{
    public class Startup
    {
        //private readonly string MyCors = "myCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Conexion"),
                    sqlServerOptionsAction: sqloptions =>
                    {
                        sqloptions.EnableRetryOnFailure();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("p1", new OpenApiInfo { Title = "Practicas", Version = "p1" });
            });

            services.AddTransient<PersonaInterface, PersonaService>();
            services.AddTransient<UsuarioInterface, UsuarioService>();
            services.AddTransient<RolInterface, RolService>();


            /*services.AddCors(op => {
                op.AddPolicy(name: MyCors, builder =>
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "http://localhost:3003/")
                    .AllowAnyHeader().AllowAnyMethod();
                });
            });*/
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => 
            {
                options.WithOrigins("http://localhost:3000");
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/p1/swagger.json", "Practicas");
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
