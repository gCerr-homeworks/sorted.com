using Refit;
using Sorted.TakeHome.API.Readings;

namespace Sorted.TakeHome.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddTransient<ICollectRainfallReadings, RainfallReader>();

            var apiBaseUrl = Configuration.GetSection("Refit:Api:BaseUrl").Get<string>();
            services.AddRefitClient<IRetrieveReadings>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
