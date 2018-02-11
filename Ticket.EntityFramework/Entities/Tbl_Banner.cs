namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Banner
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Url { get; set; }

        [Required]
        [StringLength(200)]
        public string ImgPath { get; set; }

        public int Order { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateUserId { get; set; }
    }
}
