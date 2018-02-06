using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Service
{
    public class ScenicService
    {
        private readonly ScenicRepository _scenicRepository;
        public ScenicService(ScenicRepository scenicRepository)
        {
            _scenicRepository = scenicRepository;
        }

        public Tbl_Scenic Get()
        {
            return _scenicRepository.FirstOrDefault();
        }
    }
}
