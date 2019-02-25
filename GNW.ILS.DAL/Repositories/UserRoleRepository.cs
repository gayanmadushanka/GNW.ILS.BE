using GNW.ILS.DAL.Contract.Repositories;
using GNW.ILS.DAL.Entity;
using GNW.ILS.DAL.Infrastructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GNW.ILS.DAL.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRoleEntity>, IUserRoleRepository
    {
        private readonly DbContext _dbContext;

        public UserRoleRepository(DbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserRoleEntity> GetModulesByUserRoleId(int userRoleId)
        {
            return _dbContext.Set<UserRoleEntity>().Where(x => x.Id == userRoleId).Include(x => x.ModuleEntities);
        }

        public IEnumerable<UserRoleEntity> GetUserRoles()
        {
            return _dbContext.Set<UserRoleEntity>().Include(x => x.ModuleEntities);
        }
    }
}
