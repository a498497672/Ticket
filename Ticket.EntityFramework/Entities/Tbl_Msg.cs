using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket.EntityFramework.Entities
{
    public partial class Tbl_Msg
    {
        public int Id { get; set; }

        public int MsgType { get; set; }

        public int MsgStyle { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(3000)]
        public string MsgContent { get; set; }

        public int? ToUserType { get; set; }

        public string ToUser { get; set; }

        public int DataStatus { get; set; }

        public int CreateUserId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
