using System.Threading.Tasks;
using Structure3TierDemo.Domain.BoundedContext1.Service;

namespace Structure3TierDemo.Infrastructure.UserService
{
    public class UserService : IUserService
    {
        public Task<object> GetUserAsync(string id)
        {
            return Task.FromResult((object) new {Id = id});
        }
    }
}
