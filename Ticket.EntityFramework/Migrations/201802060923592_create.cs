namespace Ticket.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Ticket",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        TicketName = c.String(nullable: false, maxLength: 50),
                        ExpiryDateStart = c.DateTime(nullable: false, storeType: "date"),
                        ExpiryDateEnd = c.DateTime(nullable: false, storeType: "date"),
                        MarkPrice = c.Decimal(precision: 9, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 9, scale: 2),
                        StockCount = c.Int(),
                        SellCount = c.Int(),
                        CheckWay = c.Int(nullable: false),
                        DelayCheck = c.Int(),
                        OrderId = c.Int(nullable: false),
                        DataStatus = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        LastUpdateTime = c.DateTime(),
                        LastUpdateUserId = c.Int(),
                        TicketSource = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        SettlementPrice = c.Decimal(precision: 9, scale: 2),
                        RuleId = c.Int(nullable: false),
                        LossFee = c.Decimal(precision: 9, scale: 2),
                        Code = c.String(maxLength: 50, unicode: false),
                        MinOQ = c.Int(nullable: false),
                        MaxOQ = c.Int(nullable: false),
                        ShelvesChannel = c.String(nullable: false, maxLength: 50),
                        IsAvailableCoupon = c.Boolean(nullable: false),
                        PicturePath = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Ticket");
        }
    }
}
