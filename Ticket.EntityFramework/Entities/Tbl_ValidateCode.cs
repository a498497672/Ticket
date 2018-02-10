using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket.EntityFramework.Entities
{
    /// <summary>
    /// 短信验证码
    /// </summary>
    public partial class Tbl_ValidateCode
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 类型：1：验证手机号；2：重置密码
        /// </summary>
        public int TypeId { get; set; }

        [Required]
        [StringLength(11)]
        public string Mobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        [StringLength(10)]
        public string ValidateCode { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否已用， true 已用 ，false 未用
        /// </summary>
        public bool DataStatus { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        [StringLength(15)]
        public string ClientIp { get; set; }
    }
}
