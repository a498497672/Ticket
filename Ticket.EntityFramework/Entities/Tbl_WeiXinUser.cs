namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_WeiXinUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string OpenId { get; set; }

        [Required]
        [StringLength(11)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public DateTime? CreateOn { get; set; }

        [StringLength(1000)]
        public string HeaderImage { get; set; }

        public int Sex { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(100)]
        public string NickName { get; set; }

        public bool IsEnable { get; set; }

        public decimal Balance { get; set; }

        public double MemberPoint { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(500)]
        public string CardNo { get; set; }

        public decimal? SaleMoney { get; set; }

        public int? MemberTypeId { get; set; }

        public bool IsMemberUser { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
