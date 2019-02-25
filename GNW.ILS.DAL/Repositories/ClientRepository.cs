using GNW.ILS.DAL.Contract.Repositories;
using GNW.ILS.DAL.Entity;
using GNW.ILS.DAL.Infrastructure;
using System.Data.Entity;

namespace GNW.ILS.DAL.Repositories
{
    public class ClientRepository : RepositoryBase<ClientEntity>, IClientRepository
    {
        public ClientRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
