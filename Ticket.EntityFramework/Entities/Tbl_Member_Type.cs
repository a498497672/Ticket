using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket.EntityFramework.Entities
{
    public partial class Tbl_Member_Type
    {
        [Key]
        public int MemberTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string MemberTypeName { get; set; }

        [StringLength(500)]
        public string ImgUrl { get; set; }

        public int RequiredPoint { get; set; }

        [StringLength(60)]
        public string LineType { get; set; }

        public decimal Discount { get; set; }

        public int DataStatus { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
