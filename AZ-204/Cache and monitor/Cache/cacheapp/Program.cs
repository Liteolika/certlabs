using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace cacheapp
{
    class Program
    {

        public static IConfiguration Configuration = BuildConfig();

        static void Main(string[] args)
        {

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                var cacheConnection = Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            var redisResponse = cache.Execute("PING");
            Console.WriteLine($"Redis response: {redisResponse}");
            var responseTime = cache.Ping();
            Console.WriteLine($"Redis responsetime: {responseTime.TotalMilliseconds}");

            cache.StringSet("key", "My Value", TimeSpan.FromSeconds(10));
            
            Console.WriteLine(cache.StringGet("key"));

            cache.Execute("FLUSHALL");
            
        }

        static IConfiguration BuildConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);
            return builder.Build();
        }
    }
}