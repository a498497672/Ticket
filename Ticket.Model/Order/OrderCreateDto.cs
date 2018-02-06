using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.Order
{
    //public class OrderCreateDto
    //{

    //}
    public class ScenicTicketDTO
    {
        /// <summary>
        /// 景区id
        /// </summary>
        public int ScenicId { get; set; }
        /// <summary>
        /// 门票Id
        /// </summary>
        public int TicketId { get; set; }
        /// <summary>
        /// 入园时间
        /// </summary>
        public DateTime TravelTime { get; set; }
        /// <summary>
        ///  购票人姓名
        /// </summary>
        public string Linkman { get; set; }
        /// <summary>
        /// 购票人手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public string Verifycode { get; set; }
        /// <summary>
        /// 购票数量
        /// </summary>
        public int BookCount { get; set; }
        /// <summary>
        /// 微信用户唯一标识id
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 优惠卷id
        /// </summary>
        public int? WeiXinPrizeUserId { get; set; }
        /// <summary>
        /// 支付方式,1.余额 2.微信
        /// </summary>
        public int PayType { get; set; }
    }
}
