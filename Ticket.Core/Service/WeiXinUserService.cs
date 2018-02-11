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
        private readonly ValidateCodeService _validateCodeService;
        public WeiXinUserService(
            WeiXinUserRepository weiXinUserRepository,
            PaymentGateway paymentGateway,
            ValidateCodeService validateCodeService)
        {
            _weiXinUserRepository = weiXinUserRepository;
            _paymentGateway = paymentGateway;
            _validateCodeService = validateCodeService;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Tbl_WeiXinUser GetByOpenId(string openId)
        {
            var weiXin_User = _weiXinUserRepository.FirstOrDefault(a => a.OpenId == openId);
            if (weiXin_User == null)
            {
                throw new SimplePromptException("用户信息获取失败");
            }
            return weiXin_User;
        }

        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Tbl_WeiXinUser CheckIsExist(string openId)
        {
            var weiXin_User = _weiXinUserRepository.FirstOrDefault(a => a.OpenId == openId);
            if (weiXin_User == null)
            {
                throw new SimplePromptException("用户信息不存在");
            }
            return weiXin_User;
        }

        /// <summary>
        /// 添加微信用户
        /// </summary>
        /// <param name="user"></param>
        public void Add(Tbl_WeiXinUser user)
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
        public void Update(Tbl_WeiXinUser user)
        {
            _weiXinUserRepository.Update(user);
        }

        /// <summary>
        /// 加入会员
        /// </summary>
        /// <param name="user"></param>
        public void AddMembership(Tbl_WeiXinUser user)
        {
            if (user.IsMemberUser)
            {
                throw new SimplePromptException("您已经是会员用户");
            }
            user.IsMemberUser = true;
            _weiXinUserRepository.Update(user);
        }

        /// <summary>
        /// 绑定openid和手机号
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="mobile"></param>
        /// <param name="verifyCode"></param>
        /// <returns></returns>
        public void BindWeChatAcount(string openId, string mobile, string verifyCode)
        {
            var weiXin_User = GetByOpenId(openId);
            if (string.IsNullOrEmpty(weiXin_User.Mobile))
            {
                if (string.IsNullOrEmpty(verifyCode))
                {
                    throw new SimplePromptException("请输入验证码");
                }
                _validateCodeService.IsValideCode(mobile, verifyCode);
                weiXin_User.Mobile = mobile;
                _weiXinUserRepository.Update(weiXin_User);
            }
        }

        /// <summary>
        /// 更新用户余额--余额支付
        /// </summary>
        /// <param name="tbl_WeiXin_User"></param>
        /// <param name="amount"></param>
        public void UpdateForBalancePay(Tbl_Order tbl_Order)
        {
            var tbl_WeiXin_User = GetByOpenId(tbl_Order.OpenId);
            tbl_WeiXin_User.Balance -= tbl_Order.TotalAmount;
            if (tbl_WeiXin_User.SaleMoney.HasValue)
            {
                tbl_WeiXin_User.SaleMoney += tbl_Order.TotalAmount;
            }
            else
            {
                tbl_WeiXin_User.SaleMoney = tbl_Order.TotalAmount;
            }
            _weiXinUserRepository.Update(tbl_WeiXin_User);
        }

        /// <summary>
        /// 修改用户余额--余额充值
        /// </summary>
        /// <param name="tbl_Order"></param>
        public void UpdateForBalanceRecharge(Tbl_Order tbl_Order)
        {
            var tbl_WeiXin_User = GetByOpenId(tbl_Order.OpenId);
            if (tbl_WeiXin_User != null)
            {
                tbl_WeiXin_User.Balance += tbl_Order.TotalAmount;
                _weiXinUserRepository.Update(tbl_WeiXin_User);
            }

        }

        /// <summary>
        /// 更新消费金额
        /// </summary>
        /// <param name="tbl_Order"></param>
        /// <param name="tbl_WeiXin_User"></param>
        public void UpdateForSaleMoney(Tbl_Order tbl_Order)
        {
            var tbl_WeiXin_User = GetByOpenId(tbl_Order.OpenId);
            if (tbl_WeiXin_User != null)
            {
                if (tbl_WeiXin_User.SaleMoney.HasValue)
                {
                    tbl_WeiXin_User.SaleMoney += tbl_Order.TotalAmount;
                }
                else
                {
                    tbl_WeiXin_User.SaleMoney = tbl_Order.TotalAmount;
                }
                _weiXinUserRepository.Update(tbl_WeiXin_User);
            }
        }
    }
}
