using System;
using System.Threading.Tasks;
using Structure3TierDemo.Domain.BoundedContext1.Model;

namespace Structure3TierDemo.Domain.BoundedContext1.Service
{
    public class FooService : IDealWithFoo
    {
        private readonly IFooRepository _fooRepository;

        public FooService(IFooRepository fooRepository)
        {
            _fooRepository = fooRepository;
        }

        public async Task<Foo> CreateFooAsync(string value)
        {
            var newId = Guid.NewGuid().ToString();
            var foo = new Foo {Id = newId, Message = value};

            await _fooRepository.CreateFooAsync(foo).ConfigureAwait(false);

            return foo;
        }
    }
}