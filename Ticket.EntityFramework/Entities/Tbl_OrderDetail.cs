namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        [StringLength(32)]
        public string OrderNo { get; set; }

        public int? SellerId { get; set; }

        public int? SellerType { get; set; }

        public int TicketSource { get; set; }

        public int TicketCategory { get; set; }

        public int? UsedQuantity { get; set; }

        public int TicketId { get; set; }

        [Required]
        [StringLength(50)]
        public string TicketName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [StringLength(20)]
        public string BarCode { get; set; }

        [StringLength(20)]
        public string Stub { get; set; }

        [StringLength(20)]
        public string CertificateNO { get; set; }

        [StringLength(20)]
        public string Linkman { get; set; }

        [StringLength(16)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string IDCard { get; set; }

        public int OrderStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? CheckTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidityDateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidityDateEnd { get; set; }

        public DateTime? CancelTime { get; set; }

        public int? PrintCount { get; set; }

        [StringLength(200)]
        public string QRcodeUrl { get; set; }

        [StringLength(100)]
        public string QRcode { get; set; }

        public int? BuyUserId { get; set; }

        public bool CanRefund { get; set; }

        public DateTime? CanRefundTime { get; set; }

        public bool CanModify { get; set; }

        public DateTime? CanModifyTime { get; set; }

        public decimal? SettlementPrice { get; set; }

        public Guid Number { get; set; }

        public int EticektSendQuantity { get; set; }

        public DateTime? DelayCheckTime { get; set; }

        public int OrderType { get; set; }

        public int OtaOrderDetailId { get; set; }

        public int OrderSource { get; set; }
    }
}
