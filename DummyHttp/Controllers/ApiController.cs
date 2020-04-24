using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace DummyHttp.Controllers
{
    [Route("/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task PostAsync()
        {
            using var reader = new StreamReader(Request.Body);
            var value = await reader.ReadToEndAsync();

            _logger.LogInformation(value);
        }

        [HttpGet]
        public string Get()
        {
            return "pong";
        }
    }
}