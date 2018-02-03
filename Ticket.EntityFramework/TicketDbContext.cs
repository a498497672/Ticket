namespace Ticket.EntityFramework
{
    using Ticket.EntityFramework.Entities;
    using System.Data.Entity;

    public partial class TicketDbContext : DbContext
    {
        public TicketDbContext()
            : base("name=TicketDbContext")
        {
        }

        public virtual DbSet<Tbl_Member_Type> Tbl_Member_Type { get; set; }
        public virtual DbSet<Tbl_Msg> Tbl_Msg { get; set; }
        public virtual DbSet<Tbl_Order> Tbl_Order { get; set; }
        public virtual DbSet<Tbl_OrderDetail> Tbl_OrderDetail { get; set; }
        public virtual DbSet<Tbl_Scenic> Tbl_Scenic { get; set; }
        public virtual DbSet<Tbl_SoundWall> Tbl_SoundWall { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_WeiXin_User> Tbl_WeiXin_User { get; set; }
        public virtual DbSet<Tbl_WeiXinBanner> Tbl_WeiXinBanner { get; set; }
        public virtual DbSet<Tbl_WeiXinIntegralConfig> Tbl_WeiXinIntegralConfig { get; set; }
        public virtual DbSet<Tbl_WeiXinIntegralDetails> Tbl_WeiXinIntegralDetails { get; set; }
        public virtual DbSet<Tbl_WeiXinPrize> Tbl_WeiXinPrize { get; set; }
        public virtual DbSet<Tbl_WeiXinPrizeConfig> Tbl_WeiXinPrizeConfig { get; set; }
        public virtual DbSet<Tbl_WeiXinPrizeUser> Tbl_WeiXinPrizeUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Member_Type>()
                .Property(e => e.MemberTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Member_Type>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Member_Type>()
                .Property(e => e.LineType)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Member_Type>()
                .Property(e => e.Discount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Tbl_Msg>()
                .Property(e => e.ToUser)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Order>()
                .Property(e => e.TotalAmount)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_Order>()
                .Property(e => e.Price)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_OrderDetail>()
                .Property(e => e.SettlementPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_OrderDetail>()
                .Property(e => e.WeiXinPrizeUserAmount)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_SoundWall>()
                .Property(e => e.OpenId)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_SoundWall>()
                .Property(e => e.CoverImage)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_SoundWall>()
                .Property(e => e.VoiceFile)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_WeiXin_User>()
                .Property(e => e.HeaderImage)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_WeiXin_User>()
                .Property(e => e.CardNo)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_WeiXin_User>()
                .Property(e => e.SaleMoney)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Tbl_WeiXinIntegralDetails>()
                .Property(e => e.TradeMoney)
                .HasPrecision(8, 2);
        }
    }
}
