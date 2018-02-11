using System.ComponentModel.DataAnnotations;

namespace Ticket.Model.Member
{
    /// <summary>
    /// 会员类型
    /// </summary>
    public class MemberTypeCreateDto
    {
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength(30, ErrorMessage = "名称不能超过30个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "图片不能为空")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int RequiredPoint { get; set; }

        public string LineType { get; set; }

        /// <summary>
        ///  折扣
        /// </summary>
        public decimal Discount { get; set; }
    }
}
