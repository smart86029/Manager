using System.Data.Entity;
using Manager.Models;

namespace Manager.Data.EntityFramework
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext db) : base(db)
        {
        }
    }
}