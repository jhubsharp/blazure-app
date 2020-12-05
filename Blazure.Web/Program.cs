using Blazure.Web.ServiceClients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Blazure.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.Configure<WeatherForecastOptions>(builder.Configuration.GetSection(WeatherForecastOptions.WeatherForecastConfig));
            builder.Services.AddHttpClient<WeatherForecastClient>();

            await builder.Build().RunAsync();
        }
    }
}
