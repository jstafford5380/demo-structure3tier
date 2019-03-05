using System.Threading.Tasks;
using Structure3TierDemo.Domain.BoundedContext1.Model;

namespace Structure3TierDemo.Domain.BoundedContext1.Service
{
    public interface IDealWithFoo
    {
        Task<Foo> CreateFooAsync(string value);
    }
}
