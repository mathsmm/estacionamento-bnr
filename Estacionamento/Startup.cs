using Estacionamento.Data;
using Estacionamento.Data.Interfaces;
using Estacionamento.Data.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Estacionamento
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

            services.AddDbContext<DataContext>(
                opt => opt.UseSqlServer(
                    Configuration.GetConnectionString("ConexaoBase")
                )
            );

            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling = 
                            ReferenceLoopHandling.Ignore
                    );

            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IRepositorioVeiculo, RepositorioVeiculo>();
            services.AddScoped<IRepositorioEstadia, RepositorioEstadia>();
            services.AddScoped<IRepositorioValorReferencia, RepositorioValorReferencia>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(
                c => c.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}