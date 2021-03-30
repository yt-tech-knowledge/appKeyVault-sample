using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AppKeyVaultSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SecretController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var connectionString = _configuration.GetValue<string>("ConnectionString");
            var authApiKey = _configuration.GetValue<string>("ApiKey");

            return Ok(new { ConnectionString = connectionString, AuthApiKey = authApiKey });
        }
    }
}
