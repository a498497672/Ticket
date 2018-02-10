using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Model.Enum;
using Ticket.Utility.Helper;

namespace Ticket.Model.Order
{
    public class OrderDetailViewDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string TicketName { get; set; }
        /// <summary>
        /// 产品购买数量
        /// </summary>
        public int BookCount { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 入园日期
        /// </summary>
        public string ValidityDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int OrderStatus { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string OrderStatusName {
            get
            {
                return ((OrderDetailStatusType)OrderStatus).GetDescriptionName();
            }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string PayTypeName
        {
            get
            {
                return ((PayType)PayType).GetDescriptionName();
            }
        }
        /// <summary>
        /// 购票人
        /// </summary>
        public string Linkman { get; set; }
        /// <summary>
        /// 购票人手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 二维码图片地址
        /// </summary>
        public string QRcodeUrl { get; set; }
        /// <summary>
        /// 凭证码
        /// </summary>
        public string CertificateNo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// 是否可退款
        /// </summary>
        public bool CanRefund { get; set; }
        /// <summary>
        /// 最后退款时间
        /// </summary>
        public string CanRefundTime { get; set; }
    }
}
