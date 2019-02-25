namespace GNW.ILS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20160829_0923 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Color = c.String(nullable: false, maxLength: 7),
                        ImagePath = c.String(nullable: false, maxLength: 100),
                        ToolTip = c.String(maxLength: 30),
                        PathToLoad = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        MiddleName = c.String(maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 128),
                        UserRoleId = c.Int(nullable: false),
                        Address = c.String(maxLength: 100),
                        HomeNumber = c.String(maxLength: 10),
                        OfficeNumber = c.String(maxLength: 10),
                        MobileNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 100),
                        ImagePath = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRole", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 400),
                        ImagePath = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoleWithModule",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRoleId, t.ModuleId })
                .ForeignKey("dbo.UserRole", t => t.UserRoleId, cascadeDelete: true)
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.ModuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRoleId", "dbo.UserRole");
            DropForeignKey("dbo.UserRoleWithModule", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.UserRoleWithModule", "UserRoleId", "dbo.UserRole");
            DropIndex("dbo.UserRoleWithModule", new[] { "ModuleId" });
            DropIndex("dbo.UserRoleWithModule", new[] { "UserRoleId" });
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.User", new[] { "UserRoleId" });
            DropIndex("dbo.User", new[] { "UserName" });
            DropTable("dbo.UserRoleWithModule");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.Module");
        }
    }
}
