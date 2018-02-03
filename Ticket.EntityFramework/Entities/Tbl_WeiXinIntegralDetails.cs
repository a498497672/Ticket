namespace Ticket.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_WeiXinIntegralDetails
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string OpenId { get; set; }

        public int WeiXinIntegralConfigId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public double Integral { get; set; }

        public DateTime CreateTime { get; set; }

        public decimal? TradeMoney { get; set; }

        public int PayType { get; set; }
    }
}
