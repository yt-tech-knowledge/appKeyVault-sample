using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AppKeyVaultSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((context, config) =>
                    {
                        var builtConfig = config.Build();

                        config.AddAzureKeyVault(builtConfig["KeyVault:Url"],
                                                builtConfig["KeyVault:ClientId"],
                                                builtConfig["KeyVault:ClientSecret"]);
                    })
                    .UseStartup<Startup>());
    }
}
