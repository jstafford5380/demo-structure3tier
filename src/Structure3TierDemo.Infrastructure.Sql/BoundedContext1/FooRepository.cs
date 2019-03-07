using System;
using System.Threading.Tasks;
using Structure3TierDemo.Domain.BoundedContext1;
using Structure3TierDemo.Domain.BoundedContext1.Model;

namespace Structure3TierDemo.Infrastructure.Sql.BoundedContext1
{
    public class FooRepository : IFooRepository
    {
        public Task<Foo> CreateFooAsync(Foo foo)
        {
            var dao = new FooData
            {
                FooId = foo.Id
            };

            // _session.Save(dao);

            // simulate database assigning id
            dao.Id = Guid.NewGuid().ToString();

            return Task.FromResult(foo);
        }
    }

    // Example: DAO is internal
    internal class FooData
    {
        public string Id { get; set; } // database key/id (implementation detail; do not let this id leave this layer)

        public string FooId { get; set; } // application ID

        public static FooData FromDomain(Foo domain) => new FooData { FooId = domain.Id };

        public Foo ToDomain() => new Foo { Id = Id };
    }
}
