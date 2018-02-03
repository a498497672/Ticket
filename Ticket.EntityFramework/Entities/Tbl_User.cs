namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string PassWord { get; set; }

        [Required]
        [StringLength(10)]
        public string RealName { get; set; }

        public int RoleId { get; set; }

        [Required]
        [StringLength(11)]
        public string Mobile { get; set; }

        public int CreateUserId { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int? LastUpdateUserId { get; set; }

        public int DataStatus { get; set; }

        public DateTime? LastLoginTime { get; set; }
    }
}
