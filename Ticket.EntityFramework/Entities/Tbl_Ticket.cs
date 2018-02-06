using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket.EntityFramework.Entities
{
    public partial class Tbl_Ticket
    {
        [Key]
        public int TicketId { get; set; }

        public int EnterpriseId { get; set; }

        public int ScenicId { get; set; }

        [Required]
        [StringLength(50)]
        public string TicketName { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpiryDateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpiryDateEnd { get; set; }

        public decimal? MarkPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int? StockCount { get; set; }

        public int? SellCount { get; set; }

        public int CheckWay { get; set; }

        public int? DelayCheck { get; set; }

        public int OrderId { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateUserId { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int? LastUpdateUserId { get; set; }

        public int TicketSource { get; set; }

        public int TypeId { get; set; }

        public decimal? SettlementPrice { get; set; }

        public int RuleId { get; set; }

        public decimal? LossFee { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public int MinOQ { get; set; }

        public int MaxOQ { get; set; }

        [Required]
        [StringLength(50)]
        public string ShelvesChannel { get; set; }

        public bool IsAvailableCoupon { get; set; }

        [StringLength(200)]
        public string PicturePath { get; set; }
    }
}
