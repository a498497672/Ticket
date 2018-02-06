using System;
using System.Collections.Generic;
using Ticket.Core.Service;
using Ticket.EntityFramework.Entities;

namespace Ticket.Application.Scenic
{
    public class ScenicFacadeService
    {
        private readonly ScenicService _scenicService;
        private readonly TicketService _ticketService;
        public ScenicFacadeService(ScenicService scenicService, TicketService ticketService)
        {
            _scenicService = scenicService;
            _ticketService = ticketService;
        }

        /// <summary>
        /// 获取景区信息
        /// </summary>
        /// <returns></returns>
        public Tbl_Scenic Get()
        {
            return _scenicService.Get();
        }

        /// <summary>
        /// 获取门票
        /// </summary>
        /// <param name="playTime"></param>
        /// <returns></returns>
        public List<Tbl_Ticket> GetTicketList(DateTime playTime)
        {
            return _ticketService.GetList(playTime);
        }
    }
}
