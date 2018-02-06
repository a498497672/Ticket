using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.User
{
    public class UserUpdateDto
    {
        public string OpenId { get; set; }
        public string HeadImgUrl { get; set; }
        public string NickName { get; set; }
        public int Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
    }
}
