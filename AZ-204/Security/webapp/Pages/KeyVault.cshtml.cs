using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class KeyVaultModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string SecretValue { get; set; }

        public KeyVaultModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            try
            {
                var keyVaultUrl = "https://az204-kv-peter.vault.azure.net/";
                var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
                var result = await client.GetSecretAsync("secretColor");
                SecretValue = result.Value.Value;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
