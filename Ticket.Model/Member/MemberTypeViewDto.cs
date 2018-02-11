namespace Ticket.Model.Member
{
    /// <summary>
    /// 会员类型
    /// </summary>
    public class MemberTypeViewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }
        public string ImgPathUrl { get; set; }
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
