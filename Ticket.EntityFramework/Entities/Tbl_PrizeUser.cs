namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_PrizeUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string OpenId { get; set; }

        public int PrizeId { get; set; }

        [Required]
        [StringLength(200)]
        public string Number { get; set; }

        public bool IsUse { get; set; }

        public DateTime? UseTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime WinningDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateUserId { get; set; }
    }
}
