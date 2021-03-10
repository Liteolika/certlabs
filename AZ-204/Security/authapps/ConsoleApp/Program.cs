using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace ConsoleApp
{
    class Program
    {

        static async Task Main()
        {
            AppConfig config = AppConfig.ReadFromJsonFile("appsettings.json");

            var app = ConfidentialClientApplicationBuilder.Create(config.ClientId)
                .WithClientSecret(config.Secret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{config.Tenant}"))
                .Build();

            var result = await app.AcquireTokenForClient(config.Scopes)
                .ExecuteAsync();
        }
    }
}
