using System.Collections.ObjectModel;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GNW.ILS.DAL.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GNW.ILS.DAL.DataBaseContext context)
        {
            context.UserDbSet.AddOrUpdate(
                p => p.UserName,
                //1
                //new UserEntity()
                //{
                //    FirstName = "Admin User",
                //    UserName = "a",
                //    Password = "/NNfWRStbZsUyc88S5tjhA==",
                //    Email = "admin@mail.com",
                //    MobileNumber = "0712222222",
                //    ImagePath = "/Images/userdefault.png",
                //    UserRole = new UserRoleEntity()
                //    {
                //        Name = "Admin User",
                //        Description = "Admin User",
                //        ModuleEntities = GetAdminModuleEntities()
                //    }
                //}
                //,
                //2
                new UserEntity()
                {
                    FirstName = "Typical User",
                    UserName = "d",
                    Password = "zXdVUpC4anLlM9Fxp9jRuQ==",
                    Email = "typical@mail.com",
                    MobileNumber = "0712222222",
                    ImagePath = "/Images/profile.png",
                    UserRole = new UserRoleEntity()
                    {
                        Name = "Typical User",
                        Description = "Typical User"
                        //,
                        //ModuleEntities = GetTypicalUserModuleEntities()
                    }
                }
            );
        }

        private static Collection<ModuleEntity> GetAdminModuleEntities()
        {
            return new Collection<ModuleEntity>
            { 
                GetModuleEntity("Client","GNW.ILS.WPF.Views.ClientView"),
                GetModuleEntity("Matter","GNW.ILS.WPF.Views.MatterView"),
            };
        }

        private static ModuleEntity GetModuleEntity(string name, string pathToLoad)
        {
            return new ModuleEntity { Name = name, Color = "#e8781a", ImagePath = "fa fa-user", ToolTip = name, PathToLoad = pathToLoad };
        }
    }
}
