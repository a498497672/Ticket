namespace Ticket.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create20180212 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_MemberType", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_MemberType", "CreateTime", c => c.DateTime());
        }
    }
}
