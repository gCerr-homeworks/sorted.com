using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sorted.TakeHome.API.Controllers;

namespace Sorted.TakeHome.API.UnitTests
{


    public class StartupTests
    {
        private IConfiguration Configuration { get; }

        public StartupTests()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.development.json")
                .Build();
        }

        [Fact]
        public void canCreate_RainfallController()
        {
            var startup = new Startup(Configuration);

            var services = new ServiceCollection();
            services.AddScoped<IConfiguration>(a => Configuration);

            startup.ConfigureServices(services);
            var sp = services.BuildServiceProvider();

            var controller = ActivatorUtilities.GetServiceOrCreateInstance<RainfallController>(sp);
            controller.Should().NotBeNull();
        }
                                     }
}
