namespace Ticket.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create20180207 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_ValidateCode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 11),
                        ValidateCode = c.String(nullable: false, maxLength: 10),
                        CreateTime = c.DateTime(nullable: false),
                        DataStatus = c.Boolean(nullable: false),
                        ClientIp = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_ValidateCode");
        }
    }
}
