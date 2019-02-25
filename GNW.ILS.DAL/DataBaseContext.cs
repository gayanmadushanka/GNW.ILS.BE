using System.Data.Entity;
using System.Transactions;
using GNW.ILS.DAL.Configurations;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.DAL
{
    public class DataBaseContext : DbContext
    {
        public virtual DbSet<UserEntity> UserDbSet { get; set; }
        public virtual DbSet<ModuleEntity> ModuleDbSet { get; set; }
        public virtual DbSet<UserRoleEntity> UserRoleDbSet { get; set; }

        public DataBaseContext()
            //: base("GNWILSSqlDbContext")
            : base("Data Source=MADUSHANKA-PC;Initial Catalog=GNW.ILS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Configuration>("PharmacyMySqlDbContext"));

            Database.SetInitializer<DataBaseContext>(null);

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new ModuleEntityConfiguration());
            modelBuilder.Configurations.Add(new UserRoleEntityConfiguration());
        }

        public virtual void Commit()
        {
            using (var transaction = new TransactionScope())
            {
                base.SaveChanges();
                transaction.Complete();
            }
        }

        public virtual void ProxyCreation(bool isEnable)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
