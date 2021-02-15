using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASP_NET5.Model.Context;
using RestWithASP_NET5.Business;
using RestWithASP_NET5.Business.Implementation;
using RestWithASP_NET5.Repository;
using Serilog;
using System.Collections.Generic;
using RestWithASP_NET5.Repository.Generic;

namespace RestWithASP_NET5
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Connetction com o Banco de Dados MySQL
            var connectionMySql = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionMySql));

            // Criando o Migrations (Para os Scripts sempre usar o Utf8) 
            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connectionMySql);
            }

            //Para poder retornar XML (Pode ser Cpmentado)
            // Quando o RespectBrowserAcceptHeader = true traz XML, quando false traz json
            services.AddMvc(options => 
            {
                options.RespectBrowserAcceptHeader = false;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
            }).AddXmlSerializerFormatters();
            
            
            
            // Versionamento de API
            services.AddApiVersioning();

            // Para Injeção de Dependencia
            services.AddScoped<IUsuarioBusiness, PresonBusinessImplementation>();
            services.AddScoped<ILivrosBusiness, LivrosBusinessImplementation>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Metodo para Migrations
        private void MigrateDatabase(string connectionMySql)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionMySql);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();

            }
            catch (System.Exception ex)
            {
                Log.Error("Database Migration failed", ex);
                throw;
            }
        }
    }
}
