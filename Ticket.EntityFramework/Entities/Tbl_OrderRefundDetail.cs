using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket.EntityFramework.Entities
{
    /// <summary>
    /// 退款
    /// </summary>
    public class Tbl_OrderRefundDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string OrderRefundNo { get; set; }

        public int OrderDetailId { get; set; }
        [Required]
        [StringLength(32)]
        public string OrderNo { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [StringLength(50)]
        public string Body { get; set; }
        /// <summary>
        /// 商品总数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 退订数量
        /// </summary>
        public int RefundQuantity { get; set; }
        /// <summary>
        /// 退款手续费
        /// </summary>
        public decimal RefundFee { get; set; }
        /// <summary>
        /// 退款总金额
        /// </summary>
        public decimal RefundTotalAmount { get; set; }
        /// <summary>
        /// 退款说明
        /// </summary>
        [StringLength(500)]
        public string RefundSummary { get; set; }
        /// <summary>
        /// 退款状态(0:申请中;1：退款成功，2：退款失败。3：拒接退款)
        /// </summary>
        public int RefundStatus { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 取消时间
        /// </summary>
        public DateTime? CancelTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
