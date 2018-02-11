using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket.EntityFramework.Entities
{
    public partial class Tbl_MemberType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string ImgUrl { get; set; }
        /// <summary>
        /// ╩Щ╥ж
        /// </summary>
        public int RequiredPoint { get; set; }

        [StringLength(60)]
        public string LineType { get; set; }

        /// <summary>
        ///  уш©ш
        /// </summary>
        public decimal Discount { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
