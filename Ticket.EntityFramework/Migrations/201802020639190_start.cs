namespace Ticket.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Tbl_Msg",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        MsgType = c.Int(nullable: false),
                        MsgStyle = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        MsgContent = c.String(maxLength: 3000),
                        ToUserType = c.Int(),
                        ToUser = c.String(unicode: false),
                        DataStatus = c.Int(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(nullable: false, maxLength: 32),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        TicketSource = c.Int(nullable: false),
                        PayType = c.Int(nullable: false),
                        PayAccount = c.String(maxLength: 200),
                        PayTradeNo = c.String(maxLength: 64),
                        SellerId = c.Int(nullable: false),
                        TicketName = c.String(nullable: false, maxLength: 50),
                        BookCount = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Linkman = c.String(maxLength: 20),
                        Mobile = c.String(nullable: false, maxLength: 16),
                        OrderStatus = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        PayTime = c.DateTime(),
                        ValidityDateStart = c.DateTime(nullable: false, storeType: "date"),
                        ValidityDateEnd = c.DateTime(nullable: false, storeType: "date"),
                        CancelTime = c.DateTime(),
                        UsedQuantity = c.Int(),
                        Remark = c.String(maxLength: 200),
                        Price = c.Decimal(precision: 9, scale: 2),
                        IDType = c.Int(),
                        IDCard = c.String(maxLength: 50),
                        CreateUserId = c.Int(nullable: false),
                        BuyUserId = c.Int(),
                        Source = c.Int(),
                        OTAOrderNo = c.String(maxLength: 32),
                        OTABusinessId = c.Int(),
                        CanRefund = c.Boolean(nullable: false),
                        CanRefundTime = c.DateTime(),
                        CanModify = c.Boolean(nullable: false),
                        CanModifyTime = c.DateTime(),
                        ReceiverName = c.String(maxLength: 50),
                        OrderType = c.Int(nullable: false),
                        GroupWay = c.Int(nullable: false),
                        OTABusinessName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Tbl_OrderDetail",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(nullable: false, maxLength: 32),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        WindowId = c.Int(),
                        SellerId = c.Int(),
                        SellerType = c.Int(),
                        TicketSource = c.Int(nullable: false),
                        TicketCategory = c.Int(nullable: false),
                        UsedQuantity = c.Int(),
                        TicketId = c.Int(nullable: false),
                        TicketName = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                        BarCode = c.String(maxLength: 20),
                        Stub = c.String(maxLength: 20),
                        CertificateNO = c.String(maxLength: 20),
                        Linkman = c.String(maxLength: 20),
                        Mobile = c.String(maxLength: 16),
                        IDCard = c.String(maxLength: 50),
                        OrderStatus = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CheckTime = c.DateTime(),
                        ValidityDateStart = c.DateTime(nullable: false, storeType: "date"),
                        ValidityDateEnd = c.DateTime(nullable: false, storeType: "date"),
                        CancelTime = c.DateTime(),
                        PrintCount = c.Int(),
                        QRcodeUrl = c.String(maxLength: 200),
                        QRcode = c.String(maxLength: 100),
                        BuyUserId = c.Int(),
                        CanRefund = c.Boolean(nullable: false),
                        CanRefundTime = c.DateTime(),
                        CanModify = c.Boolean(nullable: false),
                        CanModifyTime = c.DateTime(),
                        SettlementPrice = c.Decimal(precision: 9, scale: 2),
                        Number = c.Guid(nullable: false),
                        EticektSendQuantity = c.Int(nullable: false),
                        DelayCheckTime = c.DateTime(),
                        OrderType = c.Int(nullable: false),
                        OtaOrderDetailId = c.Int(nullable: false),
                        OrderSource = c.Int(nullable: false),
                        WeiXinPrizeUserId = c.Int(),
                        WeiXinPrizeUserAmount = c.Decimal(precision: 9, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId);
            
            CreateTable(
                "dbo.Tbl_Scenic",
                c => new
                    {
                        ScenicId = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicName = c.String(nullable: false, maxLength: 50),
                        ScenicCode = c.String(nullable: false, maxLength: 50),
                        ScenicLevel = c.Int(nullable: false),
                        ScenicAddress = c.String(maxLength: 50),
                        ProvinceId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        DistrictId = c.Int(),
                        ProvinceName = c.String(nullable: false, maxLength: 20),
                        CityName = c.String(nullable: false, maxLength: 20),
                        DistrictName = c.String(maxLength: 20),
                        FullAddress = c.String(nullable: false, maxLength: 100),
                        Tel = c.String(maxLength: 50),
                        Summary = c.String(nullable: false, maxLength: 500),
                        MainImg = c.String(nullable: false, maxLength: 150),
                        ContactMobile = c.String(nullable: false, maxLength: 11),
                        SmsCount = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        DataStatus = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        LastUpdateTime = c.DateTime(),
                        LastUpdateUserId = c.Int(),
                        SignName = c.String(maxLength: 10),
                        TicketTips = c.String(maxLength: 500),
                        SYSCodeImg = c.String(maxLength: 150),
                        SYSCode = c.String(maxLength: 150),
                        VisitorMax = c.Int(nullable: false),
                        CrowdingCriticalValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScenicId);
            
            CreateTable(
                "dbo.Tbl_SoundWall",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        OpenId = c.String(nullable: false, maxLength: 50, unicode: false),
                        ScenicSpotName = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 100),
                        CoverImage = c.String(nullable: false, maxLength: 200, unicode: false),
                        VoiceFile = c.String(nullable: false, maxLength: 200, unicode: false),
                        SecondLong = c.Int(nullable: false),
                        DataStatus = c.Int(nullable: false),
                        IsRecommend = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        UpdateUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false, maxLength: 50),
                        RealName = c.String(nullable: false, maxLength: 10),
                        RoleId = c.Int(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 11),
                        CreateUserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(),
                        LastUpdateUserId = c.Int(),
                        DataStatus = c.Int(nullable: false),
                        LastLoginTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_WeiXin_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenId = c.String(nullable: false, maxLength: 200),
                        Mobile = c.String(nullable: false, maxLength: 11),
                        Password = c.String(maxLength: 50),
                        CreateOn = c.DateTime(),
                        HeaderImage = c.String(maxLength: 1000, unicode: false),
                        Sex = c.Int(nullable: false),
                        Province = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Birthday = c.DateTime(),
                        NickName = c.String(maxLength: 100),
                        IsEnable = c.Boolean(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MemberPoint = c.Double(nullable: false),
                        LastLoginTime = c.DateTime(),
                        CardNo = c.String(maxLength: 500, unicode: false),
                        SaleMoney = c.Decimal(precision: 8, scale: 2),
                        MemberTypeId = c.Int(),
                        IsMemberUser = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_WeiXinBanner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        Title = c.String(maxLength: 200),
                        Url = c.String(nullable: false, maxLength: 500),
                        ImgPath = c.String(nullable: false, maxLength: 200),
                        Order = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_WeiXinIntegralConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.Int(nullable: false),
                        Integral = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_WeiXinIntegralDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenId = c.String(nullable: false, maxLength: 200),
                        WeiXinIntegralConfigId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Integral = c.Double(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        TradeMoney = c.Decimal(precision: 8, scale: 2),
                        PayType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_WeiXinPrize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        PrizeName = c.String(nullable: false, maxLength: 50),
                        PrizeProbability = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        PrizeType = c.Int(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsEnable = c.Boolean(nullable: false),
                        MinUseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_WeiXinPrizeConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        Frequency = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_WeiXinPrizeUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        OpenId = c.String(nullable: false, maxLength: 200),
                        PrizeId = c.Int(nullable: false),
                        Number = c.String(nullable: false, maxLength: 200),
                        IsUse = c.Boolean(nullable: false),
                        UseTime = c.DateTime(),
                        WinningDate = c.DateTime(nullable: false, storeType: "date"),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_WeiXinPrizeUser");
            DropTable("dbo.Tbl_WeiXinPrizeConfig");
            DropTable("dbo.Tbl_WeiXinPrize");
            DropTable("dbo.Tbl_WeiXinIntegralDetails");
            DropTable("dbo.Tbl_WeiXinIntegralConfig");
            DropTable("dbo.Tbl_WeiXinBanner");
            DropTable("dbo.Tbl_WeiXin_User");
            DropTable("dbo.Tbl_User");
            DropTable("dbo.Tbl_SoundWall");
            DropTable("dbo.Tbl_Scenic");
            DropTable("dbo.Tbl_OrderDetail");
            DropTable("dbo.Tbl_Order");
            DropTable("dbo.Tbl_Msg");
            DropTable("dbo.Tbl_Member_Type");
        }
    }
}
