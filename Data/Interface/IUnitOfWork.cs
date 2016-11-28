using System;
using System.Threading.Tasks;

namespace Manager.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IMenuRepository MenuRepository { get; }

        IRoleRepository RoleRepository { get; }

        IUserRepository UserRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}