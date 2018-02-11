using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Transactions;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.WeiXin;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class BannerService
    {
        private readonly BannerRepository _bannerRepository;
        public BannerService(BannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }


        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<BannerListDto> GetList()
        {
            var result = new TPageResult<BannerListDto>();
            var tbl_WeiXinPrizes = _bannerRepository.GetList().OrderBy(a => a.Order).ToList();
            List<BannerListDto> list = new List<BannerListDto>();
            foreach (var row in tbl_WeiXinPrizes)
            {
                list.Add(new BannerListDto
                {
                    Id = row.Id,
                    Title = row.Title,
                    ImgPath = row.ImgPath,
                    Order = row.Order,
                    IsEnable = row.IsEnable,
                    Url = row.Url,
                });
            }
            return result.SuccessResult(list, list.Count);
        }

        public string GetImageDomain()
        {
            return ConfigurationManager.AppSettings["UploadImageDomain"];
        }

        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public List<BannerItemDto> GetItems()
        {
            var result = new TResult<List<BannerItemDto>>();
            var tbl_WeiXinPrizes = _bannerRepository.GetList(a => a.IsEnable == true).OrderBy(a => a.Order).ToList();
            List<BannerItemDto> list = new List<BannerItemDto>();
            string domainAPI = ConfigurationManager.AppSettings["UploadImageDomain"];//图片域名或IP地址
            foreach (var row in tbl_WeiXinPrizes)
            {
                list.Add(new BannerItemDto
                {
                    Id = row.Id,
                    Title = row.Title,
                    Order = row.Order,
                    Url = row.Url,
                    ImgPathUrl = domainAPI.TrimEnd('/') + "/" + row.ImgPath,
                });
            }
            return list;
        }

        public BannerDto Get(int id)
        {
            var tbl_WeiXinBanner = _bannerRepository.Get(id);
            if (tbl_WeiXinBanner == null)
            {
                return new BannerDto();
            }
            string domainAPI = ConfigurationManager.AppSettings["UploadImageDomain"];//图片域名或IP地址
            var dto = new BannerDto
            {
                Id = tbl_WeiXinBanner.Id,
                ImgPath = tbl_WeiXinBanner.ImgPath,
                ImgPathUrl = domainAPI.TrimEnd('/') + "/" + tbl_WeiXinBanner.ImgPath,
                Url = tbl_WeiXinBanner.Url,
                Title = tbl_WeiXinBanner.Title,
                IsEnable = tbl_WeiXinBanner.IsEnable
            };
            return dto;
        }

        /// <summary>
        /// 添加轮播图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult Add(BannerDto model)
        {
            TResult result = new TResult();
            try
            {

                var tbl_WeiXinBanner = _bannerRepository.GetOrderByDescendingOrFirst();
                _bannerRepository.Add(new Tbl_Banner
                {
                    ImgPath = model.ImgPath,
                    Url = model.Url,
                    Order = tbl_WeiXinBanner == null ? 1 : tbl_WeiXinBanner.Order + 1,
                    Title = model.Title,
                    IsEnable = model.IsEnable,
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
        /// 修改轮播图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult Update(BannerDto model)
        {
            TResult result = new TResult();
            try
            {
                var tbl_WeiXinBanner = _bannerRepository.Get(model.Id);
                if (tbl_WeiXinBanner == null)
                {
                    return result.FailureResult();
                }
                tbl_WeiXinBanner.Title = model.Title;
                tbl_WeiXinBanner.ImgPath = model.ImgPath;
                tbl_WeiXinBanner.IsEnable = model.IsEnable;
                tbl_WeiXinBanner.Url = model.Url;
                _bannerRepository.Update(tbl_WeiXinBanner);
                return result.SuccessResult();
            }
            catch
            {
                return result.FailureResult();
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TResult MoveUp(int id)
        {
            TResult result = new TResult();
            try
            {
                var nowBanner = _bannerRepository.Get(id); ;
                if (nowBanner == null)
                {
                    return result.FailureResult();
                }
                var banner = _bannerRepository.GetOrderByDescendingOrFirst(a => a.Order < nowBanner.Order);
                if (banner == null)
                {
                    return result.FailureResult("当前已经是第一位");
                }
                int bannerOrder = banner.Order;
                banner.Order = nowBanner.Order;
                nowBanner.Order = bannerOrder;
                using (TransactionScope transaction = new TransactionScope())
                {
                    _bannerRepository.Update(banner);
                    _bannerRepository.Update(nowBanner);
                    _bannerRepository.SaveChanges();
                    transaction.Complete();
                }
                return result.SuccessResult("上移成功");
            }
            catch
            {
                return result.FailureResult();
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TResult MoveDown(int id)
        {
            TResult result = new TResult();
            try
            {
                var nowBanner = _bannerRepository.Get(id);
                if (nowBanner == null)
                {
                    return result.FailureResult();
                }
                var banner = _bannerRepository.GetOrderByOrFirst(a => a.Order > nowBanner.Order);
                if (banner == null)
                {
                    return result.FailureResult("当前已经是最后一位");
                }
                int bannerOrder = banner.Order;
                banner.Order = nowBanner.Order;
                nowBanner.Order = bannerOrder;
                using (TransactionScope transaction = new TransactionScope())
                {
                    _bannerRepository.Update(nowBanner);
                    _bannerRepository.Update(banner);
                    _bannerRepository.SaveChanges();
                    transaction.Complete();
                }
                return result.SuccessResult("下移成功");
            }
            catch
            {
                return result.FailureResult();
            }
        }

        public TResult UpdateIsEnable(int id)
        {
            TResult result = new TResult();
            try
            {
                var banner = _bannerRepository.Get(id);
                if (banner == null)
                {
                    return result.FailureResult();
                }
                banner.IsEnable = !banner.IsEnable;
                _bannerRepository.Update(banner);
                return result.SuccessResult();
            }
            catch
            {
                return result.FailureResult();
            }
        }
    }
}
