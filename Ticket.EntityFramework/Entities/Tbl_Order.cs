namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [StringLength(32)]
        public string OrderNo { get; set; }

        [Required]
        [StringLength(200)]
        public string OpenId { get; set; }

        public int EnterpriseId { get; set; }

        public int ScenicId { get; set; }

        public int TicketSource { get; set; }

        public int PayType { get; set; }

        [StringLength(200)]
        public string PayAccount { get; set; }

        [StringLength(64)]
        public string PayTradeNo { get; set; }

        public int SellerId { get; set; }

        [Required]
        [StringLength(50)]
        public string TicketName { get; set; }

        public int BookCount { get; set; }

        public decimal TotalAmount { get; set; }

        [StringLength(20)]
        public string Linkman { get; set; }

        [Required]
        [StringLength(16)]
        public string Mobile { get; set; }

        public int OrderStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? PayTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidityDateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidityDateEnd { get; set; }

        public DateTime? CancelTime { get; set; }

        public int? UsedQuantity { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public decimal? Price { get; set; }

        public int? IDType { get; set; }

        [StringLength(50)]
        public string IDCard { get; set; }

        public int CreateUserId { get; set; }

        public int? BuyUserId { get; set; }

        public int? Source { get; set; }

        [StringLength(32)]
        public string OTAOrderNo { get; set; }

        public int? OTABusinessId { get; set; }

        public bool CanRefund { get; set; }

        public DateTime? CanRefundTime { get; set; }

        public bool CanModify { get; set; }

        public DateTime? CanModifyTime { get; set; }

        [StringLength(50)]
        public string ReceiverName { get; set; }

        public int OrderType { get; set; }

        public int GroupWay { get; set; }

        [StringLength(200)]
        public string OTABusinessName { get; set; }
    }
}
