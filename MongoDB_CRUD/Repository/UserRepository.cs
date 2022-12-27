using Microsoft.Extensions.Options;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IOptions<DbConfiguration> settings) : base(settings)
        {
        }
    }
}
