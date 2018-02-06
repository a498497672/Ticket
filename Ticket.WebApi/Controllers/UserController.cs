using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ticket.Application.User;
using Ticket.EntityFramework.Entities;
using Ticket.Model.User;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly UserFacadeService _userFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFacadeService"></param>
        public UserController(UserFacadeService userFacadeService)
        {
            _userFacadeService = userFacadeService;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId">用户唯一标识.</param>
        /// <response code="200">成功.</response>
        /// <response code="404">数据不存在.</response>
        [Route("by")]
        [ResponseType(typeof(TResult<UserViewDto>))]
        public IHttpActionResult GetBy(string openId)
        {
            var user = _userFacadeService.GetByOpenId(openId);
            if (user == null)
            {
                return NotFound();
            }
            var userViewDto = Mapper.Map<UserViewDto>(user);
            var result = new TResult<UserViewDto>();
            return Ok(result.SuccessResult(userViewDto));
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userUpdateDto">The bill created model.</param>
        /// <response code="201">The bill created.</response>
        /// <response code="400">The bill create model is invalid.</response>
        /// <response code="401">Unauthorized.</response>
        [Route("")]
        public IHttpActionResult Post(UserUpdateDto userUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            var user = _userFacadeService.GetByOpenId(userUpdateDto.OpenId);
            if (user == null)
            {
                return NotFound();
            }
            Mapper.Map(userUpdateDto, user);
            _userFacadeService.Update(user);
            var result = new TResult();
            return Ok(result.SuccessResult());
        }

        /// <summary>
        /// 加入会员
        /// </summary>
        /// <param name="userAddMembershipDto">The bill created model.</param>
        /// <response code="201">The bill created.</response>
        /// <response code="400">The bill create model is invalid.</response>
        /// <response code="401">Unauthorized.</response>
        [Route("AddMembership")]
        public IHttpActionResult PostAddMembership(UserAddMembershipDto userAddMembershipDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            var user = _userFacadeService.GetByOpenId(userAddMembershipDto.OpenId);
            if (user == null)
            {
                return NotFound();
            }
            Mapper.Map(userAddMembershipDto, user);
            _userFacadeService.AddMembership(user);
            var result = new TResult();
            return Ok(result.SuccessResult());
        }

    }
}
