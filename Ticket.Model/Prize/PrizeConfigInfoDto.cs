namespace Ticket.Model.Prize
{
    public class PrizeConfigInfoDto
    {
        /// <summary>
        /// 是否开启抽奖
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 每人每日抽奖次数
        /// </summary>
        public int Frequency { get; set; }
        /// <summary>
        /// 用户今天抽奖剩余次数
        /// </summary>
        public int ResidualFrequency { get; set; }
        /// <summary>
        /// 抽奖时间--开始
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 抽奖时间--结束
        /// </summary>
        public string EndDate { get; set; }
    }
}
