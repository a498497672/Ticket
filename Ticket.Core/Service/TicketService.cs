using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;

namespace Ticket.Core.Service
{
    public class TicketService
    {
        private readonly TicketRepository _ticketRepository;
        public TicketService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// 获取门票
        /// </summary>
        /// <param name="playTime"></param>
        /// <returns></returns>
        public List<Tbl_Ticket> GetList(DateTime playTime)
        {
            var ticketList = _ticketRepository.GetList(p =>
                   (p.DataStatus & (int)TicketStatusType.IsStop) == 0 &&
                   p.ExpiryDateStart <= playTime.Date &&
                   p.ExpiryDateEnd >= playTime.Date).ToList();

            return ticketList;
        }

        public Tbl_Ticket Get(DateTime playTime, int ticketId)
        {
            var ticket = _ticketRepository.GetList(p =>
                    p.TicketId == ticketId &&
                   (p.DataStatus & (int)TicketStatusType.IsStop) == 0 &&
                   p.ExpiryDateStart <= playTime.Date &&
                   p.ExpiryDateEnd >= playTime.Date).FirstOrDefault();
            return ticket;
        }
    }
}
