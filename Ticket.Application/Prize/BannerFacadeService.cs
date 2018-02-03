using System.Collections.Generic;
using Ticket.Core.Service;
using Ticket.Model.WeiXin;
using Ticket.Utility.Searchs;

namespace Ticket.Application.Prize
{

    public class BannerFacadeService
    {
        private readonly BannerService _bannerService;
        public BannerFacadeService(BannerService bannerService)
        {
            _bannerService = bannerService;
        }

        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<WeiXinBannerListDto> GetList()
        {
            return _bannerService.GetList();
        }

        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TResult<List<WeiXinBannerItemDto>> GetItems()
        {
            return _bannerService.GetItems();
        }

        public WeiXinBannerDto Get(int id)
        {
            return _bannerService.Get(id);
        }

        /// <summary>
        /// 添加轮播图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult Add(WeiXinBannerDto model)
        {
            return _bannerService.Add(model);
        }

        /// <summary>
        /// 修改轮播图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult Update(WeiXinBannerDto model)
        {
            return _bannerService.Update(model);
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TResult MoveUp(int id)
        {
            return _bannerService.MoveUp(id);
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TResult MoveDown(int id)
        {
            return _bannerService.MoveDown(id);
        }

        public TResult UpdateIsEnable(int id)
        {
            return _bannerService.UpdateIsEnable(id);
        }

        public string GetImageDomain()
        {
            return _bannerService.GetImageDomain();
        }
    }
}
