using System;
using System.ComponentModel.DataAnnotations;
using Ticket.Utility.Validation;

namespace Ticket.Model.Order
{
    public class OrderRechargeDto
    {
        /// <summary>
        /// 微信用户唯一标识id
        /// </summary>
        [Required(ErrorMessage = "OpenId不能为空")]
        public string OpenId { get; set; }
        /// <summary>
        /// 充值金额 : 单位(元)
        /// </summary>
        [Required(ErrorMessage = "充值金额不能为空")]
        [Decimal(ErrorMessage = "充值金额格式无效，只有1-10的数字（包括2位小数）允许")]
        public decimal Amount { get; set; }
    }
}
