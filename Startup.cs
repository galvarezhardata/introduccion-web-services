using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CrucerosXElMundo.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrucerosXElMundo.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Agregamos los servicios necesarios para poder conectarnos con el servidor de T-SQL.
            services.AddDbContext<CrucerosXElMundoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CrucerosXElMundoConnection")));

            // Agregamos los servicios necesarios para la autenticación de datos con JwtBearerToken.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,

                    ValidIssuer = "german.com",
                    ValidAudience = "german.com",
                    // La clave debe guardarse en el json.
                    // @todo investigar como hacer eso.
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ktHguXnr5fCZNH5HXvkdt5tZ4xG2T3b3"))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
