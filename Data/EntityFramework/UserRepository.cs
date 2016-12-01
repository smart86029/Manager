using System.Data.Entity;
using Manager.Models;

namespace Manager.Data.EntityFramework
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext db) : base(db)
        {
        }
    }
}