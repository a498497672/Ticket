using System;

namespace Ticket.Model.WeiXin
{
    public class IntegralDetailsDto
    {
        public string Name { get; set; }
        public double Integral { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateTimeStr
        {
            get
            {
                return CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
