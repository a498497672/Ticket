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

        public int GetWeiXinPrizeUserCount(string openId, Tbl_WeiXinPrizeConfig tbl_WeiXinPrizeConfig)
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
        public TPageResult<WeiXinPrizeUserViewDTO> GetPrizeUserList(WeiXinPrizeUserQureyDTO model)
        {
            var result = new TPageResult<WeiXinPrizeUserViewDTO>();
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_WeiXinPrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_WeiXinPrize>();
            var tbl_WeiXin_User = PredicateBuilder.True<Tbl_WeiXin_User>();
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
                        select new WeiXinPrizeUserViewDTO
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
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TResult<List<WeiXinPrizeUserListDTO>> GetPrizeUserList(string openId)
        {
            var result = new TResult<List<WeiXinPrizeUserListDTO>>();
            if (string.IsNullOrEmpty(openId))
            {
                result.FailureResult(null, "没有找到用户信息");
            }
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_WeiXinPrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_WeiXinPrize>();
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.OpenId == openId);
            tbl_WeiXinPrize = tbl_WeiXinPrize.And(p => p.PrizeType > (int)PrizeTypeEnum.ThanksParticipation);
            var weiXinPrizeUser = _weiXinPrizeUserRepository._dbset.Where(tbl_WeiXinPrizeUser);
            var weiXinPrize = _weiXinPrizeRepository._dbset.Where(tbl_WeiXinPrize);
            var linq = (from a in weiXinPrizeUser
                        join b in weiXinPrize on a.PrizeId equals b.Id
                        select new WeiXinPrizeUserListDTO
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
            return result.SuccessResult(list);
        }

        /// <summary>
        /// 获取我的优惠卷
        /// </summary>
        /// <param name="scenicId"></param>
        /// <param name="openId"></param>
        /// <param name="IsUse">是否使用（过期的包含在已使用中）</param>
        /// <returns></returns>
        public TResult<List<WeiXinPrizeUserListDTO>> GetPrizeUserForCouponList(string openId, bool IsUse)
        {
            var result = new TResult<List<WeiXinPrizeUserListDTO>>();
            if (string.IsNullOrEmpty(openId))
            {
                result.FailureResult(null, "没有找到用户信息");
            }
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_WeiXinPrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_WeiXinPrize>();
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.OpenId == openId);
            tbl_WeiXinPrize = tbl_WeiXinPrize.And(p => p.PrizeType == (int)PrizeTypeEnum.Coupon);
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
                        select new WeiXinPrizeUserListDTO
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
            return result.SuccessResult(list);
        }

        /// <summary>
        /// 获取可以优惠卷
        /// </summary>
        /// <param name="scenicId"></param>
        /// <param name="openId"></param>
        /// <param name="amount">订单金额</param>
        /// <returns></returns>
        public TResult<List<WeiXinAvailableCouponsDto>> GetAvailableCouponsList(string openId, decimal amount)
        {
            var result = new TResult<List<WeiXinAvailableCouponsDto>>();
            var tbl_WeiXinPrizeUser = PredicateBuilder.True<Tbl_WeiXinPrizeUser>();
            var tbl_WeiXinPrize = PredicateBuilder.True<Tbl_WeiXinPrize>();
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.OpenId == openId);
            tbl_WeiXinPrize = tbl_WeiXinPrize.And(p => p.PrizeType == (int)PrizeTypeEnum.Coupon);
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1);
            tbl_WeiXinPrizeUser = tbl_WeiXinPrizeUser.And(p => p.IsUse == false & p.StartDate <= startDate & p.EndDate > endDate);
            var weiXinPrizeUser = _weiXinPrizeUserRepository._dbset.Where(tbl_WeiXinPrizeUser);
            var weiXinPrize = _weiXinPrizeRepository._dbset.Where(tbl_WeiXinPrize);
            var linq = (from a in weiXinPrizeUser
                        join b in weiXinPrize on a.PrizeId equals b.Id
                        select new WeiXinAvailableCouponsDto
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
            return result.SuccessResult(list);
        }
    }
}
