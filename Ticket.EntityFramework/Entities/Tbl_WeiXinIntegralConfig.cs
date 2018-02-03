namespace Ticket.EntityFramework.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_WeiXinIntegralConfig
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Type { get; set; }

        public double Integral { get; set; }
    }
}
