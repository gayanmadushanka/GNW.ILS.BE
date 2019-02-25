using GNW.ILS.DAL.Contract.Repositories;
using GNW.ILS.DAL.Entity;
using GNW.ILS.DAL.Infrastructure;
using System.Data.Entity;

namespace GNW.ILS.DAL.Repositories
{
    public class MatterRepository : RepositoryBase<MatterEntity>, IMatterRepository
    {
        public MatterRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
