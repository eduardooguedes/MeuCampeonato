using MeuCampeonato.Infrastructure.Data.Entitys;
using MeuCampeonato.Infrastructure.Data.Interfaces;
using MeuCampeonato.Infrastructure.Data.Repositories.Campeonato;
using MeuCampeonato.Infrastructure.Data.Repositories.Fase;
using MeuCampeonato.Infrastructure.Data.Repositories.Jogo;
using MeuCampeonato.Infrastructure.Data.Repositories.Time;
using MeuCampeonato.Services.CampeonatoService;
using MeuCampeonato.Services.FaseService;
using MeuCampeonato.Services.Interfaces;
using MeuCampeonato.Services.JogoService;
using MeuCampeonato.Services.TimeService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace MeuCampeonato.App
{
    public class Startup
    {
        private readonly string APIPolicy = "APIPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MeuCampeonato",
                    Version = "v1",
                    Description = "MeuCampeonato API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Email = "emacedoguedes@gmail.com", Name = "Eduardo Guedes" }
                });
            });

            services.AddDbContext<EntityContext>(option => option.UseSqlServer("Data Source=DESKTOP-5745ABV\\FLEETEXPRESS;User ID=dbfleet;Password=sa_fleet.com;Initial Catalog=MEU_CAMPEONATO"));

            services.AddScoped<IFaseService, FaseService>();         
            services.AddScoped<IJogoService, JogoService>();  
            services.AddScoped<ITimeService, TimeService>();  
            services.AddScoped<ICampeonatoService, CampeonatoService>();  
            
            services.AddScoped<IFaseRepository, FaseRepository>();         
            services.AddScoped<IJogoRepository, JogoRepository>();         
            services.AddScoped<ITimeRepository, TimeRepository>();         
            services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();                


            #region Seguranca - Serviço
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: APIPolicy,
                         builder =>
                         {
                             builder
                             .AllowAnyOrigin()
                             .WithMethods(
                                 "POST", "GET", "PUT"
                             )
                             .WithHeaders(HeaderNames.ContentType, "text/html, charset=UTF-8, application/octet-stream, multipart/form-data")
                             .WithExposedHeaders(HeaderNames.ContentType, "X-Custom-Header, Content-Encoding,  X-JSON")
                             ;
                         });
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeuCampeonato v1");
                c.RoutePrefix = string.Empty;
            });

            #region Segurança
            app.UseCors(APIPolicy);

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = false,
                        Private = true,
                        NoStore = true,
                        MustRevalidate = true,
                        MaxAge = TimeSpan.FromSeconds(10),
                    };

                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

                await next();
            });

            app.UseResponseCaching();
            app.UseHttpsRedirection();
            #endregion


        }
    }
}
