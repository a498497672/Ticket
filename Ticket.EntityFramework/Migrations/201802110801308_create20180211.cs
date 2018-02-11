namespace Ticket.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create20180211 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tbl_WeiXin_User", newName: "Tbl_WeiXinUser");
            RenameTable(name: "dbo.Tbl_WeiXinBanner", newName: "Tbl_Banner");
            RenameTable(name: "dbo.Tbl_WeiXinIntegralConfig", newName: "Tbl_IntegralConfig");
            RenameTable(name: "dbo.Tbl_WeiXinIntegralDetails", newName: "Tbl_IntegralDetails");
            RenameTable(name: "dbo.Tbl_WeiXinPrize", newName: "Tbl_Prize");
            RenameTable(name: "dbo.Tbl_WeiXinPrizeConfig", newName: "Tbl_PrizeConfig");
            RenameTable(name: "dbo.Tbl_WeiXinPrizeUser", newName: "Tbl_PrizeUser");
            CreateTable(
                "dbo.Tbl_MemberType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        ImgUrl = c.String(maxLength: 500, unicode: false),
                        RequiredPoint = c.Int(nullable: false),
                        LineType = c.String(maxLength: 60, unicode: false),
                        Discount = c.Decimal(nullable: false, precision: 8, scale: 2),
                        DataStatus = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_OrderRefundDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderRefundNo = c.String(nullable: false, maxLength: 32),
                        OrderDetailId = c.Int(nullable: false),
                        OrderNo = c.String(nullable: false, maxLength: 32),
                        Body = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                        RefundQuantity = c.Int(nullable: false),
                        RefundFee = c.Decimal(nullable: false, precision: 9, scale: 2),
                        RefundTotalAmount = c.Decimal(nullable: false, precision: 9, scale: 2),
                        RefundSummary = c.String(maxLength: 500),
                        RefundStatus = c.Int(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        CancelTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tbl_Order", "OpenId", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Tbl_Msg", "EnterpriseId");
            DropColumn("dbo.Tbl_Msg", "ScenicId");
            DropColumn("dbo.Tbl_Order", "EnterpriseId");
            DropColumn("dbo.Tbl_Order", "ScenicId");
            DropColumn("dbo.Tbl_Order", "GroupWay");
            DropColumn("dbo.Tbl_Order", "OTABusinessName");
            DropColumn("dbo.Tbl_OrderDetail", "EnterpriseId");
            DropColumn("dbo.Tbl_OrderDetail", "ScenicId");
            DropColumn("dbo.Tbl_OrderDetail", "WindowId");
            DropColumn("dbo.Tbl_OrderDetail", "WeiXinPrizeUserId");
            DropColumn("dbo.Tbl_OrderDetail", "WeiXinPrizeUserAmount");
            DropColumn("dbo.Tbl_SoundWall", "EnterpriseId");
            DropColumn("dbo.Tbl_SoundWall", "ScenicId");
            DropColumn("dbo.Tbl_Banner", "EnterpriseId");
            DropColumn("dbo.Tbl_Banner", "ScenicId");
            DropColumn("dbo.Tbl_Prize", "EnterpriseId");
            DropColumn("dbo.Tbl_Prize", "ScenicId");
            DropColumn("dbo.Tbl_PrizeConfig", "EnterpriseId");
            DropColumn("dbo.Tbl_PrizeConfig", "ScenicId");
            DropColumn("dbo.Tbl_PrizeUser", "EnterpriseId");
            DropColumn("dbo.Tbl_PrizeUser", "ScenicId");
            DropTable("dbo.Tbl_Member_Type");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tbl_Member_Type",
                c => new
                    {
                        MemberTypeId = c.Int(nullable: false, identity: true),
                        MemberTypeName = c.String(nullable: false, maxLength: 50, unicode: false),
                        ImgUrl = c.String(maxLength: 500, unicode: false),
                        RequiredPoint = c.Int(nullable: false),
                        LineType = c.String(maxLength: 60, unicode: false),
                        Discount = c.Decimal(nullable: false, precision: 8, scale: 2),
                        DataStatus = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.MemberTypeId);
            
            AddColumn("dbo.Tbl_PrizeUser", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_PrizeUser", "EnterpriseId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_PrizeConfig", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_PrizeConfig", "EnterpriseId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Prize", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Prize", "EnterpriseId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Banner", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Banner", "EnterpriseId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_SoundWall", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_SoundWall", "EnterpriseId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_OrderDetail", "WeiXinPrizeUserAmount", c => c.Decimal(precision: 9, scale: 2));
            AddColumn("dbo.Tbl_OrderDetail", "WeiXinPrizeUserId", c => c.Int());
            AddColumn("dbo.Tbl_OrderDetail", "WindowId", c => c.Int());
            AddColumn("dbo.Tbl_OrderDetail", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_OrderDetail", "EnterpriseId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Order", "OTABusinessName", c => c.String(maxLength: 200));
            AddColumn("dbo.Tbl_Order", "GroupWay", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Order", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Order", "EnterpriseId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Msg", "ScenicId", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Msg", "EnterpriseId", c => c.Int(nullable: false));
            DropColumn("dbo.Tbl_Order", "OpenId");
            DropTable("dbo.Tbl_OrderRefundDetail");
            DropTable("dbo.Tbl_MemberType");
            RenameTable(name: "dbo.Tbl_PrizeUser", newName: "Tbl_WeiXinPrizeUser");
            RenameTable(name: "dbo.Tbl_PrizeConfig", newName: "Tbl_WeiXinPrizeConfig");
            RenameTable(name: "dbo.Tbl_Prize", newName: "Tbl_WeiXinPrize");
            RenameTable(name: "dbo.Tbl_IntegralDetails", newName: "Tbl_WeiXinIntegralDetails");
            RenameTable(name: "dbo.Tbl_IntegralConfig", newName: "Tbl_WeiXinIntegralConfig");
            RenameTable(name: "dbo.Tbl_Banner", newName: "Tbl_WeiXinBanner");
            RenameTable(name: "dbo.Tbl_WeiXinUser", newName: "Tbl_WeiXin_User");
        }
    }
}
