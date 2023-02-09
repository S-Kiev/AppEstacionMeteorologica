using Dominio.Repositorios;
using Dominio.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistencia.Data;
using Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObliProgApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ObliProgApi", Version = "v1" });
            });

            services.AddDbContext<NuestroContexto>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("StrConnMaikol")));

            services.AddTransient<DispositivoServicio>();
            services.AddTransient<TipoDispositivoServicio>();
            services.AddTransient<UsuarioServicio>();
            services.AddTransient<EstacionServicio>();
            services.AddTransient<IDispositivo, RepositorioDispositivo>();
            services.AddTransient<ITipoDispositivo, RepositorioTipoDispositivo>();
            services.AddTransient<IEstacion, RepositorioEstacion>();
            services.AddTransient<IUsuario, RepositorioUsuario>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ObliProgApi v1"));
            }

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
