
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
using WebApi_CODIFICO.Models;

namespace WebApi_CODIFICO
    {
        public class TestStartup
        {
            public IConfiguration Configuration { get; }

            public TestStartup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                // Aquí puedes configurar tus servicios, como el DbContext
                services.AddDbContext<StoreSampleContext>();
                services.AddHealthChecks();
                services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }

        public class MyDbContext
        {
            // Aquí puedes definir tu DbContext y configurarlo, si es necesario
        }

        public class MyController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get()
            {
                // Aquí puedes acceder al DbContext para realizar pruebas
                return Ok();
            }
        }
    }

