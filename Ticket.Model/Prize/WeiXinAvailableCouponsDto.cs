using System;

namespace Ticket.Model.Prize
{
    public class WeiXinAvailableCouponsDto
    {
        public int Id { get; set; }
        public bool IsUse { get; set; }
        public string PrizeName { get; set; }
        public decimal Money { get; set; }
        public decimal MinUseAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string UseDate
        {
            get
            {
                return StartDate.ToString("yyyy-MM-dd") + " 至 " + EndDate.ToString("yyyy-MM-dd");
            }
        }
    }
}
