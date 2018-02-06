using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.Scenic
{
    /// <summary>
    /// 
    /// </summary>
    public class ScenicViewDto
    {
        /// <summary>
        /// 景区名称
        /// </summary>
        public string ScenicName { get; set; }
        /// <summary>
        /// 详细介绍
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string FullAddress { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 购票须知(富文本)
        /// </summary>
        public string TicketNotice { get; set; }

        /// <summary>
        /// 领游绑定的用户id
        /// </summary>
        public string LyUserId { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string MainImg { get; set; }
    }
}
