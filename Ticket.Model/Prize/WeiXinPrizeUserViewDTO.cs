using System;

namespace Ticket.Model.Prize
{
    public class WeiXinPrizeUserViewDTO
    {
        public string OpenId { get; set; }
        public string Number { get; set; }
        public bool IsUse { get; set; }
        public string IsUseName
        {
            get
            {
                return IsUse ? "已使用" : "未使用";
            }
        }
        public System.DateTime WinningDate { get; set; }
        public string WinningDateName
        {
            get
            {
                return WinningDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string Name { get; set; }
        public string PrizeName { get; set; }
        public int UserId { get; set; }
        public string UserNickName { get; set; }
        public decimal MinUseAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string UseDate
        {
            get
            {
                return StartDate.ToString("yyyy-MM-dd") + " - " + EndDate.ToString("yyyy-MM-dd");
            }
        }
    }
}
