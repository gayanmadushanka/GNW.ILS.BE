using GNW.ILS.DAL.Entity;
using System.Collections.Generic;

namespace GNW.ILS.DAL.Contract.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRoleEntity>
    {
        IEnumerable<UserRoleEntity> GetModulesByUserRoleId(int userRoleId);
        IEnumerable<UserRoleEntity> GetUserRoles();
    }
}
