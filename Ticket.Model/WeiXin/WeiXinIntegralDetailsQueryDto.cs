namespace Ticket.Model.WeiXin
{
    public class WeiXinIntegralDetailsQueryDto
    {
        public string OpenId { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int Limit { get; set; }
    }
}
