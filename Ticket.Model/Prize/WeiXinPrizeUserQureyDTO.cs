using System;

namespace Ticket.Model.Prize
{
    public class WeiXinPrizeUserQureyDTO
    {
        public int ScenicId { get; set; }
        public string Number { get; set; }
        public int? UserId { get; set; }
        public string UserNickName { get; set; }
        /// <summary>
        /// 中奖类型
        /// </summary>
        public string WinningType { get; set; }
        /// <summary>
        /// 中奖时间
        /// </summary>
        public DateTime? WinningTime { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
