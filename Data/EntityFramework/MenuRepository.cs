using System.Data.Entity;
using Manager.Models;

namespace Manager.Data.EntityFramework
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(DbContext db) : base(db)
        {
        }
    }
}