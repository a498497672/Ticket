using System;
using System.Collections.Generic;
using System.Linq;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Common;
using Ticket.Model.Enum;
using Ticket.Model.Prize;
using Ticket.Utility.Helper;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class PrizeService
    {
        private readonly PrizeRepository _prizeRepository;
        private readonly PrizeConfigService _prizeConfigService;
        private readonly PrizeUserService _prizeUserService;

        public PrizeService(
            PrizeRepository prizeRepository,
            PrizeConfigService prizeConfigService,
            PrizeUserService prizeUserService)
        {
            _prizeRepository = prizeRepository;
            _prizeConfigService = prizeConfigService;
            _prizeUserService = prizeUserService;
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<PrizeViewDto> GetPrizeList()
        {
            var result = new TPageResult<PrizeViewDto>();
            var tbl_WeiXinPrizes = _prizeRepository.GetList();
            List<PrizeViewDto> list = new List<PrizeViewDto>();
            foreach (var row in tbl_WeiXinPrizes)
            {
                list.Add(new PrizeViewDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    PrizeName = row.PrizeName,
                    PrizeProbability = row.PrizeProbability,
                    Money = row.Money,
                    PrizeType = row.PrizeType,
                    Stock = row.Stock,
                    IsEnable = row.IsEnable,
                    MinUseAmount = row.MinUseAmount,
                    StartDate = row.StartDate,
                    EndDate = row.EndDate
                });
            }
            return result.SuccessResult(list, list.Count);
        }

        public List<SelectItemDto> GetPrizeItem()
        {
            var list = new List<SelectItemDto>();
            var tbl_WeiXinPrizes = _prizeRepository.GetList();
            foreach (var row in tbl_WeiXinPrizes)
            {
                list.Add(new SelectItemDto
                {
                    Name = row.Name,
                    Value = row.PrizeName
                });
            }
            return list;
        }

        public PrizeDto GetPrize(int id)
        {
            var entity = _prizeRepository.Get(id);
            return new PrizeDto
            {
                Id = entity.Id,
                Stock = entity.Stock,
                IsEnable = entity.IsEnable,
                PrizeProbability = entity.PrizeProbability,
                Name = entity.Name,
                PrizeName = entity.PrizeName,
                PrizeType = entity.PrizeType,
                Money = entity.Money,
                MinUseAmount = entity.MinUseAmount,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult AddPrize(PrizeDto model)
        {
            TResult result = new TResult();
            try
            {
                _prizeRepository.Add(new Tbl_Prize
                {
                    Name = model.Name,
                    PrizeName = model.PrizeName,
                    PrizeProbability = model.PrizeProbability,
                    Money = model.Money,
                    PrizeType = model.PrizeType,
                    Stock = model.Stock,
                    IsEnable = model.IsEnable,
                    MinUseAmount = model.MinUseAmount,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CreateTime = DateTime.Now,
                    CreateUserId = 0
                });
                return result.SuccessResult();
            }
            catch
            {
                return result.FailureResult();
            }
        }

        /// <summary>
        /// 修改奖品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult UpdatePrize(PrizeDto model)
        {
            TResult result = new TResult();
            try
            {
                var tbl_WeiXinPrize = _prizeRepository.Get(model.Id);
                if (tbl_WeiXinPrize == null)
                {
                    return result.FailureResult();
                }
                tbl_WeiXinPrize.Name = model.Name;
                tbl_WeiXinPrize.PrizeName = model.PrizeName;
                tbl_WeiXinPrize.PrizeProbability = model.PrizeProbability;
                tbl_WeiXinPrize.Money = model.Money;
                tbl_WeiXinPrize.PrizeType = model.PrizeType;
                tbl_WeiXinPrize.Stock = model.Stock;
                tbl_WeiXinPrize.IsEnable = model.IsEnable;
                tbl_WeiXinPrize.MinUseAmount = model.MinUseAmount;
                tbl_WeiXinPrize.StartDate = model.StartDate;
                tbl_WeiXinPrize.EndDate = model.EndDate;

                _prizeRepository.Update(tbl_WeiXinPrize);
                return result.SuccessResult();
            }
            catch
            {
                return result.FailureResult();
            }
        }

        /// <summary>
        /// 开始抽奖
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public PrizeWinningDto DrawStart(string openId)
        {
            var tbl_PrizeConfig = _prizeConfigService.CheckIsDraw();
            _prizeUserService.CheckDrawFrequency(tbl_PrizeConfig, openId);
            var tbl_WeiXinPrize = Draw();
            if (tbl_WeiXinPrize == null || tbl_WeiXinPrize.Stock <= 0)
            {
                return UpdateWeiXinPrizeUserForThanks(openId);
            }
            return Update(openId, tbl_WeiXinPrize);
        }

        private PrizeWinningDto UpdateWeiXinPrizeUserForThanks(string openId)
        {
            var tbl_WeiXinPrize = _prizeRepository.FirstOrDefault(p => p.PrizeType == (int)PrizeType.ThanksParticipation);
            return Update(openId, tbl_WeiXinPrize);
        }

        private PrizeWinningDto Update(string openId, Tbl_Prize tbl_WeiXinPrize)
        {
            _prizeUserService.Add(tbl_WeiXinPrize, openId);
            UpdateWeiXinPrize(tbl_WeiXinPrize);
            return new PrizeWinningDto
            {
                Name = tbl_WeiXinPrize.Name,
                PrizeName = tbl_WeiXinPrize.PrizeName
            };
        }

        /// <summary>
        /// 修改奖品库存
        /// </summary>
        /// <param name="tbl_WeiXinPrize"></param>
        private void UpdateWeiXinPrize(Tbl_Prize tbl_WeiXinPrize)
        {
            tbl_WeiXinPrize.Stock--;
            _prizeRepository.Update(tbl_WeiXinPrize);
        }

        /// <summary>
        /// 抽奖
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        private Tbl_Prize Draw()
        {
            var result = _prizeRepository.GetList();
            var prizeProbability = result.Sum(a => a.PrizeProbability);
            int maxValue = (int)(prizeProbability * 100);
            Random ran = new Random();
            int number = ran.Next(maxValue);
            int max = 0;
            int min = 0;
            foreach (var row in result)
            {
                int value = (int)(row.PrizeProbability * 100);
                max += value;
                if (number >= min && number < max)
                {
                    return row;
                }
                min += value;
            }
            return null;
        }
    }
}
