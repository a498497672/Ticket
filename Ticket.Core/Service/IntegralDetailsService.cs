using System;
using System.Linq;
using System.Transactions;
using Ticket.Core.Repository;
using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;
using Ticket.Model.WeiXin;
using Ticket.Utility.Helper;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class IntegralDetailsService
    {
        private readonly IntegralDetailsRepository _integralDetailsRepository;
        private readonly WeiXinUserRepository _weiXinUserRepository;
        private readonly IntegralConfigRepository _integralConfigRepository;
        private readonly MemberTypeRepository _memberTypeRepository;

        public IntegralDetailsService(
            IntegralDetailsRepository integralDetailsRepository,
            WeiXinUserRepository weiXinUserRepository,
            IntegralConfigRepository integralConfigRepository,
            MemberTypeRepository memberTypeRepository)
        {
            _integralDetailsRepository = integralDetailsRepository;
            _weiXinUserRepository = weiXinUserRepository;
            _integralConfigRepository = integralConfigRepository;
            _memberTypeRepository = memberTypeRepository;
        }


        /// <summary>
        /// 获取积分明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PagedResult<WeiXinIntegralDetailsDto> GetList(WeiXinIntegralDetailsQueryDto model)
        {
            var tbl_WeiXinIntegralDetails = _integralDetailsRepository._dbset.Where(a => a.OpenId == model.OpenId && a.Integral > 0);
            var linq = (from a in tbl_WeiXinIntegralDetails
                        select new WeiXinIntegralDetailsDto
                        {
                            Name = a.Name,
                            Integral = a.Integral,
                            CreateTime = a.CreateTime
                        }).OrderByDescending(c => c.CreateTime);
            var pageList = PaginationHelper.FindPagedList(model.Page, model.Limit, linq);
            return pageList;
        }

        /// <summary>
        /// 用户登录加积分
        /// </summary>
        /// <param name="openId"></param>
        public void AddIntegralForEverydayLogin(string openId)
        {
            using (TransactionScope tran = new TransactionScope())
            {

                AddIntegral(new WeiXinIntegralDetailsCreateDto
                {
                    OpenId = openId,
                    Amount = 1,
                    Name = "用户登录",
                    Type = IntegralType.EverydayLogin
                });
                _integralDetailsRepository.SaveChanges();
                tran.Complete();
            }
        }

        /// <summary>
        /// 添加用户积分--余额消费
        /// </summary>
        /// <param name="tbl_Order"></param>
        public void AddForBalanceConsumption(Tbl_Order tbl_Order)
        {
            AddIntegral(new WeiXinIntegralDetailsCreateDto
            {
                OpenId = tbl_Order.OpenId,
                Amount = tbl_Order.TotalAmount,
                Name = "购买景区门票",
                Type = IntegralType.Consumption,
                PayType = PayType.Balance
            });
        }

        /// <summary>
        /// 添加用户积分--微信消费
        /// </summary>
        /// <param name="tbl_Order"></param>
        public void AddForWechatConsumption(Tbl_Order tbl_Order)
        {
            AddIntegral(new WeiXinIntegralDetailsCreateDto
            {
                OpenId = tbl_Order.OpenId,
                Amount = tbl_Order.TotalAmount,
                Name = "购买景区门票",
                Type = IntegralType.Consumption,
                PayType = PayType.Wechat
            });
        }

        /// <summary>
        /// 添加用户积分--充值
        /// </summary>
        /// <param name="tbl_Order"></param>
        public void AddForRecharge(Tbl_Order tbl_Order)
        {
            AddIntegral(new WeiXinIntegralDetailsCreateDto
            {
                OpenId = tbl_Order.OpenId,
                Amount = tbl_Order.TotalAmount,
                Name = "购买景区门票",
                Type = IntegralType.Recharge,
                PayType = PayType.Balance
            });
        }


        /// <summary>
        /// 添加积分明细和会员用户累计积分
        /// </summary>
        /// <param name="model"></param>
        private void AddIntegral(WeiXinIntegralDetailsCreateDto model)
        {
            var tbl_WeiXin_User = _weiXinUserRepository.FirstOrDefault(a => a.OpenId == model.OpenId);
            if (tbl_WeiXin_User == null)
            {
                return;
            }
            if (model.Type == IntegralType.EverydayLogin)//每日登录
            {
                var startDate = DateTime.Now.Date;
                var endDate = startDate.AddDays(1);
                var count = _integralDetailsRepository.Count(a =>
                    a.OpenId == model.OpenId &
                    a.CreateTime >= startDate &
                    a.CreateTime < endDate);
                tbl_WeiXin_User.LastLoginTime = DateTime.Now;
                _weiXinUserRepository.Update(tbl_WeiXin_User);
                if (count > 0 || !tbl_WeiXin_User.IsMemberUser)//说明今天已经赠送过积分了
                {
                    return;
                }
            }
            var entity = _integralConfigRepository.FirstOrDefault(a => a.Type == (int)model.Type);
            if (entity == null)
            {
                return;
            }
            double integral = 0;
            if (tbl_WeiXin_User.IsMemberUser)
            {
                integral = Math.Round(Convert.ToDouble(model.Amount) * entity.Integral, 2);
                tbl_WeiXin_User.MemberPoint += integral;
                tbl_WeiXin_User.MemberTypeId = GetMemberTypeId((int)tbl_WeiXin_User.MemberPoint);
                _weiXinUserRepository.Update(tbl_WeiXin_User);
            }
            var createEntity = new Tbl_WeiXinIntegralDetails
            {
                Name = model.Name,
                OpenId = model.OpenId,
                Integral = integral,
                WeiXinIntegralConfigId = entity.Id,
                CreateTime = DateTime.Now,
                TradeMoney = model.Amount,
                PayType = (int)model.PayType
            };
            _integralDetailsRepository.Add(createEntity);
        }

        public int GetMemberTypeId(int point)
        {
            var tbl_Member_Type = _memberTypeRepository._dbset.Where(a => a.RequiredPoint <= point).OrderByDescending(a => a.RequiredPoint).FirstOrDefault();
            if (tbl_Member_Type == null)
            {
                return 0;
            }
            return tbl_Member_Type.MemberTypeId;
        }
    }
}
