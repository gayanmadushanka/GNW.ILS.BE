using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Managers;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.DAL.Configurations
{
    public class ModuleEntityConfiguration : EntityTypeConfiguration<ModuleEntity>
    {
        public ModuleEntityConfiguration()
        {
            ToTable(ConstantManager.ModuleTableName);
            HasKey(c => c.Id);
            Property(c => c.Name).HasMaxLength(ConstantManager.NamePropertyLength).IsRequired();
            Property(c => c.Color).HasMaxLength(ConstantManager.ColorPropertyLength).IsRequired();
            Property(c => c.ImagePath).HasMaxLength(ConstantManager.ImagePathPropertyLength).IsRequired();
            Property(c => c.ToolTip).HasMaxLength(ConstantManager.ToolTipPropertyLength).IsOptional();
            Property(c => c.PathToLoad).HasMaxLength(ConstantManager.PathToLoadPropertyLength).IsRequired();
        }
    }
}
