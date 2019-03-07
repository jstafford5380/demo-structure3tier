using System;
using System.Threading.Tasks;
using Structure3TierDemo.Domain.BoundedContext1.Model;

namespace Structure3TierDemo.Domain.BoundedContext1.Service
{
    public class FooService : IFooService
    {
        private readonly IFooRepository _fooRepository;
        private readonly IUserService _userService;

        public FooService(IFooRepository fooRepository, IUserService userService)
        {
            _fooRepository = fooRepository;
            _userService = userService;
        }

        public async Task<Foo> CreateFooAsync()
        {
            var newId = Guid.NewGuid().ToString();
            var foo = new Foo {Id = newId};
            foo.DoThing();

            await _fooRepository.CreateFooAsync(foo).ConfigureAwait(false);

            return foo;
        }
    }
}