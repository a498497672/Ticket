using System;
using System.Collections.Generic;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Common;
using Ticket.Model.Prize;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class PrizeService
    {
        private readonly PrizeRepository _weiXinPrizeRepository;

        public PrizeService(PrizeRepository weiXinPrizeRepository)
        {
            _weiXinPrizeRepository = weiXinPrizeRepository;
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<WeiXinPrizeViewDTO> GetPrizeList()
        {
            var result = new TPageResult<WeiXinPrizeViewDTO>();
            var tbl_WeiXinPrizes = _weiXinPrizeRepository.GetList();
            List<WeiXinPrizeViewDTO> list = new List<WeiXinPrizeViewDTO>();
            foreach (var row in tbl_WeiXinPrizes)
            {
                list.Add(new WeiXinPrizeViewDTO
                {
                    Id = row.Id,
                    ScenicId = row.ScenicId,
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
            var tbl_WeiXinPrizes = _weiXinPrizeRepository.GetList();
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

        public WeiXinPrizeDTO GetPrize(int id)
        {
            var entity = _weiXinPrizeRepository.Get(id);
            return new WeiXinPrizeDTO
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
        public TResult AddPrize(WeiXinPrizeDTO model)
        {
            TResult result = new TResult();
            try
            {
                _weiXinPrizeRepository.Add(new Tbl_WeiXinPrize
                {
                    EnterpriseId = model.EnterpriseId,
                    ScenicId = model.ScenicId,
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
        public TResult UpdatePrize(WeiXinPrizeDTO model)
        {
            TResult result = new TResult();
            try
            {
                var tbl_WeiXinPrize = _weiXinPrizeRepository.Get(model.Id);
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

                _weiXinPrizeRepository.Update(tbl_WeiXinPrize);
                return result.SuccessResult();
            }
            catch
            {
                return result.FailureResult();
            }
        }
    }
}
