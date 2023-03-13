using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using Newtonsoft.Json;
using System.Net.Http;
using WebApi_CODIFICO.Models;
using WebApi_CODIFICO;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTesting.Tests
{
    public class CustomerValidatorShould
    {
        private TestServer _server;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            // Configurar una instancia de la base de datos para las pruebas
            var options = new DbContextOptionsBuilder<StoreSampleContext>()
                .UseSqlServer("Data Source=DESKTOP-EF0DCME\\SQLEXPRESS;Initial Catalog=StoreSample;Integrated Security=True; TrustServerCertificate=True")
                .Options;

            // Configurar el TestServer
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .ConfigureTestServices(services =>
                {
                    services.AddScoped<StoreSampleContext>(provider => new StoreSampleContext(options));
                }));

            _client = _server.CreateClient();
        }

        [Test]
        public async Task Test_Orders()
        {
            // Enviar una solicitud HTTP a la aplicación utilizando el TestServer
            var response = await _client.GetAsync("/api/Orders/Listall");

            // Validar la respuesta obtenida
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Customer>(content);

            Assert.IsNotNull(model);
        }

        [Test]
        public async Task Test_Customer()
        {
            // Enviar una solicitud HTTP a la aplicación utilizando el TestServer
            var response = await _client.GetAsync("/api/Customer/Listall");

            // Validar la respuesta obtenida
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Customer>(content);

            Assert.IsNotNull(model);
        }

        [TearDown]
        public void Teardown()
        {
            _client.Dispose();
            _server.Dispose();
        }
    }
}