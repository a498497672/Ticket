﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Utility.Searchs
{
    public class TResult
    {
        public TResult()
        {
            this.Success = false;
            this.Message = "请求失败";
        }

        public TResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        /// <summary>
        ///  是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }


        public TResult CommonResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
            return this;
        }

        public virtual TResult SuccessResult(string message = "成功")
        {
            return CommonResult(true, message);
        }

        public virtual TResult FailureResult(string message = "失败")
        {
            return CommonResult(false, message);
        }

        public virtual string GetMessage()
        {
            return Success ? "成功" : "失败";
        }
    }

    public class TResult<T> : TResult
    {
        public TResult()
            : base()
        {
            this.Data = default(T);
        }

        public TResult(bool success, string message, T data)
            : base(success, message)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
            this.Success = data != null;
        }

        /// <summary>
        /// 返回码
        /// </summary>
        public string Code { get; set; }

        public T Data { get; set; }

        public TResult<T> CommonResult(bool success, string message, T data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
            this.Code = success ? "200" : "500";
            success = data != null;
            return this;
        }

        public TResult<T> SuccessResult(T data, string message = "成功")
        {
            return CommonResult(true, message, data);
        }

        public TResult<T> FailureResult(T data, string message = "失败")
        {
            return CommonResult(false, message, data);
        }
    }
}
