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

        public virtual DbSet<Tbl_MemberType> Tbl_MemberType { get; set; }
        public virtual DbSet<Tbl_Msg> Tbl_Msg { get; set; }
        public virtual DbSet<Tbl_Order> Tbl_Order { get; set; }
        public virtual DbSet<Tbl_OrderDetail> Tbl_OrderDetail { get; set; }
        public virtual DbSet<Tbl_Scenic> Tbl_Scenic { get; set; }
        public virtual DbSet<Tbl_SoundWall> Tbl_SoundWall { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_WeiXinUser> Tbl_WeiXinUser { get; set; }
        public virtual DbSet<Tbl_Banner> Tbl_Banner { get; set; }
        public virtual DbSet<Tbl_IntegralConfig> Tbl_IntegralConfig { get; set; }
        public virtual DbSet<Tbl_IntegralDetails> Tbl_IntegralDetails { get; set; }
        public virtual DbSet<Tbl_Prize> Tbl_Prize { get; set; }
        public virtual DbSet<Tbl_PrizeConfig> Tbl_PrizeConfig { get; set; }
        public virtual DbSet<Tbl_PrizeUser> Tbl_PrizeUser { get; set; }
        public virtual DbSet<Tbl_Ticket> Tbl_Ticket { get; set; }
        public virtual DbSet<Tbl_ValidateCode> Tbl_ValidateCode { get; set; }
        public virtual DbSet<Tbl_OrderRefundDetail> Tbl_OrderRefundDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_MemberType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MemberType>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MemberType>()
                .Property(e => e.LineType)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MemberType>()
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

            modelBuilder.Entity<Tbl_SoundWall>()
                .Property(e => e.OpenId)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_SoundWall>()
                .Property(e => e.CoverImage)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_SoundWall>()
                .Property(e => e.VoiceFile)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_WeiXinUser>()
                .Property(e => e.HeaderImage)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_WeiXinUser>()
                .Property(e => e.CardNo)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_WeiXinUser>()
                .Property(e => e.SaleMoney)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Tbl_IntegralDetails>()
                .Property(e => e.TradeMoney)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Tbl_Ticket>()
                .Property(e => e.MarkPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_Ticket>()
                .Property(e => e.SalePrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_Ticket>()
                .Property(e => e.SettlementPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_Ticket>()
                .Property(e => e.LossFee)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_Ticket>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Ticket>()
                .Property(e => e.PicturePath)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_OrderRefundDetail>()
                .Property(e => e.Price)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_OrderRefundDetail>()
                .Property(e => e.RefundFee)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Tbl_OrderRefundDetail>()
                .Property(e => e.RefundTotalAmount)
                .HasPrecision(9, 2);
        }
    }
}
