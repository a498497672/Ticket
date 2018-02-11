using System;
using System.Collections.Generic;
using Ticket.Core.Repository;
using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Service
{
    /// <summary>
    /// 会员类型
    /// </summary>
    public class MemberTypeService
    {
        private readonly MemberTypeRepository _memberTypeRepository;
        public MemberTypeService(MemberTypeRepository memberTypeRepository)
        {
            _memberTypeRepository = memberTypeRepository;
        }

        public Tbl_MemberType Get(int id)
        {
            return _memberTypeRepository.Get(id);
        }

        public List<Tbl_MemberType> GetList()
        {
            return _memberTypeRepository.GetList();
        }

        public void Add(Tbl_MemberType tbl_MemberType)
        {
            tbl_MemberType.LineType = "";
            tbl_MemberType.DataStatus = 1;
            tbl_MemberType.CreateTime = DateTime.Now;
            _memberTypeRepository.Add(tbl_MemberType);
        }

        public void Update(Tbl_MemberType tbl_MemberType)
        {
            _memberTypeRepository.Update(tbl_MemberType);
        }

        public void Delete(int id)
        {
            var tbl_MemberType = _memberTypeRepository.FirstOrDefault(a => a.Id == id);
            if (tbl_MemberType != null)
            {
                _memberTypeRepository.Delete(tbl_MemberType);
            }
        }
    }
}
