namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Scenic
    {
        [Key]
        public int ScenicId { get; set; }

        public int EnterpriseId { get; set; }

        [Required]
        [StringLength(50)]
        public string ScenicName { get; set; }

        [Required]
        [StringLength(50)]
        public string ScenicCode { get; set; }

        public int ScenicLevel { get; set; }

        [StringLength(50)]
        public string ScenicAddress { get; set; }

        public int ProvinceId { get; set; }

        public int CityId { get; set; }

        public int? DistrictId { get; set; }

        [Required]
        [StringLength(20)]
        public string ProvinceName { get; set; }

        [Required]
        [StringLength(20)]
        public string CityName { get; set; }

        [StringLength(20)]
        public string DistrictName { get; set; }

        [Required]
        [StringLength(100)]
        public string FullAddress { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [Required]
        [StringLength(500)]
        public string Summary { get; set; }

        [Required]
        [StringLength(150)]
        public string MainImg { get; set; }

        [Required]
        [StringLength(11)]
        public string ContactMobile { get; set; }

        public int SmsCount { get; set; }

        public int OrderId { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateUserId { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int? LastUpdateUserId { get; set; }

        [StringLength(10)]
        public string SignName { get; set; }

        [StringLength(500)]
        public string TicketTips { get; set; }

        [StringLength(150)]
        public string SYSCodeImg { get; set; }

        [StringLength(150)]
        public string SYSCode { get; set; }

        public int VisitorMax { get; set; }

        public int CrowdingCriticalValue { get; set; }
    }
}
