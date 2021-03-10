using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    public class AppConfig
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Tenant { get; set; }
        public string[] Scopes { get; set; }

        public static AppConfig ReadFromJsonFile(string path)
        {
            IConfigurationRoot Configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path);

            Configuration = builder.AddUserSecrets<AppConfig>().Build();
            return Configuration.Get<AppConfig>();
        }
    }
}
