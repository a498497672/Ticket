using System;
using Ticket.Model.Enum;
using Ticket.Utility.Helper;

namespace Ticket.Model.Prize
{
    public class WeiXinPrizeViewDTO
    {
        public int Id { get; set; }
        public int EnterpriseId { get; set; }
        public int ScenicId { get; set; }
        public string Name { get; set; }
        public string PrizeName { get; set; }
        public double PrizeProbability { get; set; }
        public int Stock { get; set; }
        public int PrizeType { get; set; }
        public string PrizeTypeName
        {
            get
            {
                return ((PrizeTypeEnum)PrizeType).GetDescription<PrizeTypeEnum>();
            }
        }
        public decimal Money { get; set; }
        public bool IsEnable { get; set; }
        public string IsEnableName
        {
            get
            {
                return IsEnable ? "启用" : "不启用";
            }
        }
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
