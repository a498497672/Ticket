using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Service;
using Ticket.EntityFramework.Entities;

namespace Ticket.Application.Member
{
    public class MemberTypeFacadeService
    {
        private readonly MemberTypeService _memberTypeService;
        public MemberTypeFacadeService(MemberTypeService memberTypeService)
        {
            _memberTypeService = memberTypeService;
        }

        public Tbl_MemberType Get(int id)
        {
            return _memberTypeService.Get(id);
        }

        public List<Tbl_MemberType> GetList()
        {
            return _memberTypeService.GetList();
        }

        public void Add(Tbl_MemberType tbl_MemberType)
        {
            _memberTypeService.Add(tbl_MemberType);
        }

        public void Update(Tbl_MemberType tbl_MemberType)
        {
            _memberTypeService.Update(tbl_MemberType);
        }

        public void Delete(int id)
        {
            _memberTypeService.Delete(id);
        }
    }
}
