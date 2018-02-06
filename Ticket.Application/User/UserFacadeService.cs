using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Service;
using Ticket.EntityFramework.Entities;

namespace Ticket.Application.User
{
    public class UserFacadeService
    {
        private readonly WeiXinUserService _weiXinUserService;
        public UserFacadeService(WeiXinUserService weiXinUserService )
        {
            _weiXinUserService = weiXinUserService;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Tbl_WeiXin_User GetByOpenId(string openId)
        {
            return _weiXinUserService.GetByOpenId(openId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        public void Update(Tbl_WeiXin_User user)
        {
            _weiXinUserService.Update(user);
        }

        /// <summary>
        /// 加入会员
        /// </summary>
        /// <param name="user"></param>
        public void AddMembership(Tbl_WeiXin_User user)
        {
            _weiXinUserService.AddMembership(user);
        }
    }
}
