using System.Collections.Generic;

namespace GNW.ILS.DAL.Entity
{
    public class UserRoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<ModuleEntity> ModuleEntities { get; set; }
        public ICollection<UserEntity> UserEntities { get; set; }
    }
}
