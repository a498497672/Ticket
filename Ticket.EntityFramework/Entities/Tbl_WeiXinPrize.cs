namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_WeiXinPrize
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public int ScenicId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string PrizeName { get; set; }

        public double PrizeProbability { get; set; }

        public int Stock { get; set; }

        public int PrizeType { get; set; }

        public decimal Money { get; set; }

        public bool IsEnable { get; set; }

        public decimal MinUseAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateUserId { get; set; }
    }
}
