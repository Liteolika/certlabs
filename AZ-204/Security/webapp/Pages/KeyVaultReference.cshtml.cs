using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class KeyVaultReferenceModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuraiton;

        public string SecretValue { get; set; }

        public KeyVaultReferenceModel(ILogger<IndexModel> logger, IConfiguration configuraiton)
        {
            _logger = logger;
            _configuraiton = configuraiton;
        }

        public async Task OnGet()
        {
            SecretValue = _configuraiton.GetSection("SecretColor").Value;
        }
    }
}
