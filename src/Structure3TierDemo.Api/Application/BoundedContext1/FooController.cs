using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Structure3TierDemo.Domain.BoundedContext1.Service;

namespace Structure3TierDemo.Api.Application.BoundedContext1
{
    [Route("[controller]")]
    public class FooController : Controller
    {
        private readonly IDealWithFoo _fooService;

        public FooController(IDealWithFoo fooService)
        {
            _fooService = fooService;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> PostFoo([FromBody] FooRequestInfo request)
        {
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