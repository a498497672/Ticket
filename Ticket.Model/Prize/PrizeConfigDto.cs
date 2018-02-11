namespace Ticket.Model.Prize
{
    public class PrizeConfigDto
    {
        public int EnterpriseId { get; set; }
        public int ScenicId { get; set; }
        public bool IsEnable { get; set; }
        public int Frequency { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }
    }
}
