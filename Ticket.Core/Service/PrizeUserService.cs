using System;
using System.Collections.Generic;
using System.Linq;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;
using Ticket.Model.Prize;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Helper;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class PrizeUserService
    {
        private readonly PrizeUserRepository _weiXinPrizeUserRepository;
        private readonly WeiXinUserRepository _weiXinUserRepository;
        private readonly PrizeRepository _weiXinPrizeRepository;

        public PrizeUserService(
            PrizeUserRepository weiXinPrizeUserRepository,
            WeiXinUserRepository weiXinUserRepository,
            PrizeRepository weiXinPrizeRepository)
        {
            _weiXinPrizeUserRepository = weiXinPrizeUserRepository;
            _weiXinUserRepository = weiXinUserRepository;
            _weiXinPrizeRepository = weiXinPrizeRepository;
        }

        public int GetWeiXinPrizeUserCount(string openId, Tbl_PrizeConfig tbl_WeiXinPrizeConfig)
        {
            var dateNow = DateTime.Now;
            DateTime endDate = tbl_WeiXinPrizeConfig.EndDate.AddDays(1);
            var tbl_WeiXinPrizeUserCount = _weiXinPrizeUserRepository.Count(p =>
                p.OpenId == openId &
                p.CreateTime >= tbl_WeiXinPrizeConfig.StartDate.Date &
                p.CreateTime < endDate.Date &
                p.WinningDate == dateNow.Date);
            return tbl_WeiXinPrizeUserCount;
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<PrizeUserViewDto> GetPrizeUserList(PrizeUserQureyDto model)
        {
            var result = new TPageResult<PrizeUserViewDto>();
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_PrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_Prize>();
            var tbl_WeiXin_User = PredicateBuilder.True<Tbl_WeiXinUser>();
            //tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.ScenicId == model.ScenicId);
            if (!string.IsNullOrEmpty(model.Number))
            {
                tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(o => o.Number == model.Number);
            }
            if (model.WinningTime.HasValue)
            {
                tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(o => o.WinningDate == model.WinningTime.Value);
            }
            if (!string.IsNullOrEmpty(model.WinningType))
            {
                tbl_WeiXinPrize = tbl_WeiXinPrize.And(o => o.Name == model.WinningType);
            }
            if (model.UserId.HasValue)
            {
                tbl_WeiXin_User = tbl_WeiXin_User.And(o => o.Id == model.UserId);
            }
            if (!string.IsNullOrEmpty(model.UserNickName))
            {
                tbl_WeiXin_User = tbl_WeiXin_User.And(o => o.NickName.Contains(model.UserNickName));
            }

            var weiXinPrizeUser = _weiXinPrizeUserRepository._dbset.Where(tbl_WeiXinPrizeUser);
            var weiXinPrize = _weiXinPrizeRepository._dbset.Where(tbl_WeiXinPrize);
            var weiXin_User = _weiXinUserRepository._dbset.Where(tbl_WeiXin_User);
            var linq = (from a in weiXinPrizeUser
                        join b in weiXinPrize on a.PrizeId equals b.Id
                        join c in weiXin_User on a.OpenId equals c.OpenId
                        select new PrizeUserViewDto
                        {
                            OpenId = a.OpenId,
                            IsUse = a.IsUse,
                            Number = a.Number,
                            WinningDate = a.CreateTime,
                            Name = b.Name,
                            PrizeName = b.PrizeName,
                            UserId = c.Id,
                            UserNickName = c.NickName,
                            MinUseAmount = b.MinUseAmount,
                            StartDate = a.StartDate,
                            EndDate = a.EndDate
                        }).OrderByDescending(c => c.WinningDate);
            var pageList = PaginationHelper.FindPagedList(model.Page, model.Limit, linq);
            return result.SuccessResult(pageList.Data, pageList.TotalCount);
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public List<PrizeUserListDto> GetPrizeUserList(string openId)
        {
            if (string.IsNullOrEmpty(openId))
            {
                return null;
            }
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_PrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_Prize>();
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.OpenId == openId);
            tbl_WeiXinPrize = tbl_WeiXinPrize.And(p => p.PrizeType > (int)PrizeType.ThanksParticipation);
            var weiXinPrizeUser = _weiXinPrizeUserRepository._dbset.Where(tbl_WeiXinPrizeUser);
            var weiXinPrize = _weiXinPrizeRepository._dbset.Where(tbl_WeiXinPrize);
            var linq = (from a in weiXinPrizeUser
                        join b in weiXinPrize on a.PrizeId equals b.Id
                        select new PrizeUserListDto
                        {
                            IsUse = a.IsUse,
                            Number = a.Number,
                            WinningDate = a.CreateTime,
                            Name = b.Name,
                            PrizeName = b.PrizeName,
                            MinUseAmount = b.MinUseAmount,
                            StartDate = a.StartDate,
                            EndDate = a.EndDate
                        }).OrderByDescending(c => c.WinningDate);
            var list = linq.ToList();
            return list;
        }

        /// <summary>
        /// 获取我的优惠卷
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="IsUse">是否使用（过期的包含在已使用中）</param>
        /// <returns></returns>
        public List<PrizeUserListDto> GetPrizeUserForCouponList(string openId, bool IsUse)
        {
            if (string.IsNullOrEmpty(openId))
            {
                return null;
            }
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_PrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_Prize>();
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.OpenId == openId);
            tbl_WeiXinPrize = tbl_WeiXinPrize.And(p => p.PrizeType == (int)PrizeType.Coupon);
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1);
            if (IsUse)//已使用
            {
                tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => (p.IsUse == true || p.EndDate < startDate));
            }
            else//未使用
            {
                tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.IsUse == false && p.StartDate <= startDate & p.EndDate > endDate);
            }
            var weiXinPrizeUser = _weiXinPrizeUserRepository._dbset.Where(tbl_WeiXinPrizeUser);
            var weiXinPrize = _weiXinPrizeRepository._dbset.Where(tbl_WeiXinPrize);
            var linq = (from a in weiXinPrizeUser
                        join b in weiXinPrize on a.PrizeId equals b.Id
                        select new PrizeUserListDto
                        {
                            IsUse = a.IsUse,
                            Number = a.Number,
                            WinningDate = a.CreateTime,
                            Name = b.Name,
                            PrizeName = b.PrizeName,
                            Money = b.Money,
                            MinUseAmount = b.MinUseAmount,
                            StartDate = a.StartDate,
                            EndDate = a.EndDate
                        }).OrderByDescending(c => c.WinningDate);
            var list = linq.ToList();
            return list;
        }

        /// <summary>
        /// 获取可以优惠卷
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="amount">订单金额</param>
        /// <returns></returns>
        public List<AvailableCouponsDto> GetAvailableCouponsList(string openId, decimal amount)
        {
            if (string.IsNullOrEmpty(openId))
            {
                return null;
            }
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_PrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_Prize>();
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.OpenId == openId);
            tbl_WeiXinPrize = tbl_WeiXinPrize.And(p => p.PrizeType == (int)PrizeType.Coupon);
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1);
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.IsUse == false & p.StartDate <= startDate & p.EndDate > endDate);
            var weiXinPrizeUser = _weiXinPrizeUserRepository._dbset.Where(tbl_WeiXinPrizeUser);
            var weiXinPrize = _weiXinPrizeRepository._dbset.Where(tbl_WeiXinPrize);
            var linq = (from a in weiXinPrizeUser
                        join b in weiXinPrize on a.PrizeId equals b.Id
                        select new AvailableCouponsDto
                        {
                            Id = a.Id,
                            IsUse = b.MinUseAmount <= amount ? true : false,
                            PrizeName = b.PrizeName,
                            Money = b.Money,
                            MinUseAmount = b.MinUseAmount,
                            StartDate = a.StartDate,
                            EndDate = a.EndDate
                        }).OrderByDescending(c => new { c.IsUse, c.Money });
            var list = linq.ToList();
            return list;
        }

        /// <summary>
        /// 检查抽奖次数是否用完
        /// </summary>
        /// <param name="tbl_PrizeConfig">抽奖配置</param>
        /// <param name="openId">微信用户唯一标识</param>
        public void CheckDrawFrequency(Tbl_PrizeConfig tbl_PrizeConfig, string openId)
        {
            var dateNow = DateTime.Now;
            DateTime endDate = tbl_PrizeConfig.EndDate.AddDays(1);
            var tbl_WeiXinPrizeUserCount = _weiXinPrizeUserRepository.Count(p =>
                p.OpenId == openId &
                p.CreateTime >= tbl_PrizeConfig.StartDate.Date &
                p.CreateTime < endDate.Date &
                p.WinningDate == dateNow.Date);
            if (tbl_WeiXinPrizeUserCount >= tbl_PrizeConfig.Frequency)
            {
                throw new SimplePromptException("您的抽奖次数已用完");
            }
        }

        /// <summary>
        /// 添加中奖信息
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="tbl_WeiXinPrize"></param>
        public void Add(Tbl_Prize tbl_WeiXinPrize, string openId)
        {
            var Tbl_WeiXinPrizeUser = new Tbl_PrizeUser
            {
                OpenId = openId,
                PrizeId = tbl_WeiXinPrize.Id,
                IsUse = false,
                Number = OrderHelper.GenerateOrderNo(),
                StartDate = tbl_WeiXinPrize.StartDate,
                EndDate = tbl_WeiXinPrize.EndDate,
                CreateTime = DateTime.Now,
                WinningDate = DateTime.Now,
                CreateUserId = 0
            };
            _weiXinPrizeUserRepository.Add(Tbl_WeiXinPrizeUser);
        }
    }
}
