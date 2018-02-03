namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_SoundWall
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public int ScenicId { get; set; }

        [Required]
        [StringLength(50)]
        public string OpenId { get; set; }

        [Required]
        [StringLength(100)]
        public string ScenicSpotName { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string CoverImage { get; set; }

        [Required]
        [StringLength(200)]
        public string VoiceFile { get; set; }

        public int SecondLong { get; set; }

        public int DataStatus { get; set; }

        public bool IsRecommend { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? UpdateUserId { get; set; }
    }
}
