namespace Ticket.Model.Prize
{
    public class PrizeDto
    {
        public int Id { get; set; }
        public int EnterpriseId { get; set; }
        public int ScenicId { get; set; }
        public string Name { get; set; }
        public string PrizeName { get; set; }
        public double PrizeProbability { get; set; }
        public int Stock { get; set; }
        public int PrizeType { get; set; }
        public decimal Money { get; set; }
        public bool IsEnable { get; set; }
        public decimal MinUseAmount { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}
