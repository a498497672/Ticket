using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Model.Enum;
using Ticket.Utility.Helper;

namespace Ticket.Model.User
{
    public class UserViewDto
    {
        public string HeadImgUrl { get; set; }
        public string NickName { get; set; }
        public string SexDes
        {
            get
            {
                return ((SexType)Sex).GetDescription<SexType>();
            }
        }
        public int Sex { get; set; }
        public string Birthday { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
    }
}
