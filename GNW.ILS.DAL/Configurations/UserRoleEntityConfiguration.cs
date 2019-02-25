using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Managers;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.DAL.Configurations
{
    public class UserRoleEntityConfiguration : EntityTypeConfiguration<UserRoleEntity>
    {
        public UserRoleEntityConfiguration()
        {
            ToTable(ConstantManager.UserRoleTableName);
            HasKey(c => c.Id);
            Property(c => c.Name).HasMaxLength(ConstantManager.NamePropertyLength).IsRequired();
            Property(c => c.Description).HasMaxLength(ConstantManager.DescriptionPropertyLength).IsOptional();
            Property(c => c.ImagePath).HasMaxLength(ConstantManager.ImagePathPropertyLength).IsOptional();
            HasMany(c => c.ModuleEntities).WithMany().Map(c => { c.ToTable(ConstantManager.UserRoleWithModuleTableName); c.MapLeftKey(ConstantManager.UserRoleWithModuleLeftColumn); c.MapRightKey(ConstantManager.UserRoleWithModuleRightColumn); });
            HasMany(c => c.UserEntities).WithRequired().HasForeignKey(c => c.UserRoleId);
        }
    }
}
