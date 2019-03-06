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
        private readonly IDealWithFoo _fooService;
        private readonly ILogger _logger;
        private SampleConfig _sampleConfig;

        public FooController(IDealWithFoo fooService, IOptions<SampleConfig> sampleConfig, ILogger<FooController> logger)
        {
            _fooService = fooService;
            _logger = logger;
            _sampleConfig = sampleConfig.Value;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> PostFoo([FromBody] FooRequestInfo request)
        {
            _logger.LogCritical($"Inner value is: {_sampleConfig.Inner1.InnerProp}");

            var result = await _fooService
                .CreateFooAsync(request.Message)
                .ConfigureAwait(false);

            var payload = new FooResponseInfo
            {
                Id = result.Id,
                Message = result.Message
            };

            return Created($"/Foo/{payload.Id}", payload);
        }
    }
}