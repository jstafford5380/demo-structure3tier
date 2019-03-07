using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Structure3TierDemo.Api.Installers;
using Structure3TierDemo.Domain.BoundedContext1.Service;

namespace Structure3TierDemo.Api.Application.BoundedContext1
{
    [Route("[controller]")]
    public class FooController : Controller
    {
        private readonly IFooService _fooService;
        private readonly ILogger _logger;
        private readonly SampleConfig _sampleConfig;

        public FooController(
            IFooService fooService, 
            IOptions<SampleConfig> sampleConfig, 
            ILogger<FooController> logger)
        {
            _fooService = fooService;
            _logger = logger;

            // Example: Use IOptions pattern
            _sampleConfig = sampleConfig.Value;
        }

        [HttpPost, Route("", Name = nameof(PostFoo))]
        public async Task<IActionResult> PostFoo([FromBody] FooRequestInfo request)
        {
            _logger.LogCritical($"Inner value to: {_sampleConfig.Inner1.InnerProp}");

            var result = await _fooService
                .CreateFooAsync()
                .ConfigureAwait(false);

            // Example: Mapping pattern for contracts
            var payload = FooResponseInfo.FromDomain(result);

            return Created($"/foo/{payload.Id}", payload);
        }
    }
}