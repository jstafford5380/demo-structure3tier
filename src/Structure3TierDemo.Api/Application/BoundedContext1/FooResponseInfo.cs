using Structure3TierDemo.Domain.BoundedContext1.Model;

namespace Structure3TierDemo.Api.Application.BoundedContext1
{
    public class FooResponseInfo
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public static FooResponseInfo FromDomain(Foo info)
        {
            return new FooResponseInfo
            {
                Id = info.Id,
                Message = info.Message
            };
        }

        public Foo ToDomain()
        {
            return new Foo {Id = Id};
        }
    }
}