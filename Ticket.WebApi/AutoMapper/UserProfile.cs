using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;
using Ticket.Model.Order;
using Ticket.Model.Scenic;
using Ticket.Model.User;
using Ticket.Model.WeiXin;

namespace Ticket.WebApi.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void Configure()
        {
            CreateMap<Tbl_WeiXinUser, UserViewDto>()
                .ForMember(bp => bp.HeadImgUrl, opt => opt.MapFrom(p => p.HeaderImage))
                .ForMember(bp => bp.Birthday, opt => opt.MapFrom(p => p.Birthday.HasValue ? p.Birthday.Value.ToString("yyyy-MM-dd") : ""));
            CreateMap<UserUpdateDto, Tbl_WeiXinUser>()
                .ForMember(bp => bp.HeaderImage, opt => opt.MapFrom(p => p.HeadImgUrl));
            CreateMap<Model.User.UserAddMembershipDto, Tbl_WeiXinUser>();
            CreateMap<Tbl_IntegralConfig, IntegralConfigViewDto>();
            CreateMap<Tbl_Scenic, ScenicViewDto>()
                .ForMember(bp => bp.TicketNotice, opt => opt.MapFrom(p => p.TicketTips));

            CreateMap<Tbl_Ticket, TicketViewDto>();

            CreateMap<Tbl_Order, OrderViewDto>()
                 .ForMember(bp => bp.ValidityDate, opt => opt.MapFrom(p => p.ValidityDateStart.ToString("yyyy-MM-dd") + " 至 " + p.ValidityDateEnd.ToString("yyyy-MM-dd")));
            CreateMap<Tbl_OrderDetail, OrderDetailViewDto>()
                .ForMember(bp => bp.CreateDate, opt => opt.MapFrom(p => p.ValidityDateEnd.ToString("yyyy-MM-dd")))
                .ForMember(bp => bp.ValidityDate, opt => opt.MapFrom(p => p.ValidityDateStart.ToString("yyyy-MM-dd") + " 至 " + p.ValidityDateEnd.ToString("yyyy-MM-dd")));
        }
    }
}