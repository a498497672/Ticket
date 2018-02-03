namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_WeiXinPrizeConfig
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public int ScenicId { get; set; }

        public bool IsEnable { get; set; }

        public int Frequency { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
    }
}
