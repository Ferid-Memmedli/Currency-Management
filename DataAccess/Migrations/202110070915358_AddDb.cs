namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 64, fixedLength: true),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.Email, unique: true, name: "Index1");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "Index1");
            DropTable("dbo.Users");
        }
    }
}
