using System;
using GNW.ILS.DAL.Contract.Repositories;

namespace GNW.ILS.DAL.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        IModuleDetailsRepository ModuleDetailsRepository { get; }
        IUserDetailsRepository UserDetailsRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IClientRepository ClientRepository { get; }
        IMatterRepository MatterRepository { get; }
    }
}
