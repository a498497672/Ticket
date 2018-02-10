using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Utility.Validation;

namespace Ticket.Model.Order
{
    public class OrderCreateDto
    {
        /// <summary>
        /// 门票Id
        /// </summary>
        [Required(ErrorMessage = "门票Id不能为空")]
        public int TicketId { get; set; }
        /// <summary>
        /// 入园时间
        /// </summary>
        [Required(ErrorMessage = "入园时间不能为空")]
        public DateTime TravelTime { get; set; }
        /// <summary>
        ///  购票人姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        public string Linkman { get; set; }
        /// <summary>
        /// 购票人手机号码
        /// </summary>
        [Required(ErrorMessage = "手机号码不能为空")]
        [Mobile(ErrorMessage = "手机格式不正确")]
        public string Mobile { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public string Verifycode { get; set; }
        /// <summary>
        /// 购票数量
        /// </summary>
        [Range(1, 99, ErrorMessage = "购票数量必须在1 - 99之间")]
        public int BookCount { get; set; }
        /// <summary>
        /// 微信用户唯一标识id
        /// </summary>
        [Required(ErrorMessage = "OpenId不能为空")]
        public string OpenId { get; set; }
        /// <summary>
        /// 优惠卷id
        /// </summary>
        public int? WeiXinPrizeUserId { get; set; }
    }
}
