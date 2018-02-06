using System;
using Ticket.Core.Repository;
using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;
using Ticket.Infrastructure.WxPay;
using Ticket.Utility.Exceptions;

namespace Ticket.Core.Service
{
    public class WeiXinUserService
    {
        private readonly WeiXinUserRepository _weiXinUserRepository;
        private readonly PaymentGateway _paymentGateway;
        public WeiXinUserService(WeiXinUserRepository weiXinUserRepository, PaymentGateway paymentGateway)
        {
            _weiXinUserRepository = weiXinUserRepository;
            _paymentGateway = paymentGateway;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Tbl_WeiXin_User GetByOpenId(string openId)
        {
            return _weiXinUserRepository.FirstOrDefault(a => a.OpenId == openId);
        }

        /// <summary>
        /// 添加微信用户
        /// </summary>
        /// <param name="user"></param>
        public void Add(Tbl_WeiXin_User user)
        {
            user.Balance = 0;
            user.CardNo = "";
            user.CreateOn = DateTime.Now;
            user.IsEnable = true;
            user.IsMemberUser = false;
            user.MemberPoint = 0;
            user.Name = "";
            user.Password = "";
            user.Mobile = "";
            _weiXinUserRepository.Add(user);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        public void Update(Tbl_WeiXin_User user)
        {
            _weiXinUserRepository.Update(user);
        }

        /// <summary>
        /// 加入会员
        /// </summary>
        /// <param name="user"></param>
        public void AddMembership(Tbl_WeiXin_User user)
        {
            if (user.IsMemberUser)
            {
                throw new SimplePromptException("您已经是会员用户");
            }
            user.IsMemberUser = true;
            _weiXinUserRepository.Update(user);
        }
    }
}
