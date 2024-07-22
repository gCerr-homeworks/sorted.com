using Sorted.TakeHome.API.Readings;
using Refit;
using Sorted.TakeHome.API;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        try
        {
            await CreateHostBuilder(args)
                .Build()
                .RunAsync();
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, ex.Message);
            return 1;
        }
        finally
        {
            Serilog.Log.CloseAndFlush();
        }

        return 0;
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}