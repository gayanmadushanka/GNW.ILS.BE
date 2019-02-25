using GNW.ILS.DAL.Contract;
using GNW.ILS.DAL.Contract.Repositories;
using GNW.ILS.DAL.Repositories;
using System;
using System.Data.Entity;

namespace GNW.ILS.DAL.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IModuleDetailsRepository ModuleDetailsRepository { get; }
        public IUserDetailsRepository UserDetailsRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IClientRepository ClientRepository { get; }
        public IMatterRepository MatterRepository { get; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            ModuleDetailsRepository = new Lazy<IModuleDetailsRepository>(() => new ModuleDetailsRepository(dbContext), false).Value;
            UserDetailsRepository = new Lazy<IUserDetailsRepository>(() => new UserDetailsRepository(dbContext), false).Value;
            UserRoleRepository = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(dbContext), false).Value;
            ClientRepository = new Lazy<IClientRepository>(() => new ClientRepository(dbContext), false).Value;
            MatterRepository = new Lazy<IMatterRepository>(() => new MatterRepository(dbContext), false).Value;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        //private readonly IDatabaseFactory _databaseFactory;
        //private DataBaseContext _dataContext;

        //public UnitOfWork(IDatabaseFactory databaseFactory)
        //{
        //    _databaseFactory = databaseFactory;
        //}

        //protected DataBaseContext DataContext
        //{
        //    get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        //}

        //public void Commit()
        //{
        //    DataContext.Commit();
        //}

        //public void ProxyCreation(bool isEnable = true)
        //{
        //    DataContext.ProxyCreation(isEnable);
        //}
    }
}
