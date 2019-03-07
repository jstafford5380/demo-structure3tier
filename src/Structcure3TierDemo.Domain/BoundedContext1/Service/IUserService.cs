using System.Threading.Tasks;

namespace Structure3TierDemo.Domain.BoundedContext1.Service
{
    public interface IUserService
    {
        Task<object> GetUserAsync(string id);
    }
}
