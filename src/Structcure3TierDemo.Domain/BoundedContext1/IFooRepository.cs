using System.Threading.Tasks;
using Structure3TierDemo.Domain.BoundedContext1.Model;

namespace Structure3TierDemo.Domain.BoundedContext1
{
    public interface IFooRepository
    {
        Task<Foo> CreateFooAsync(Foo foo);
    }
}
