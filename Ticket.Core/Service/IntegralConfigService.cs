using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;
using Ticket.Model.WeiXin;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class IntegralConfigService
    {
        private readonly IntegralConfigRepository _integralConfigRepository;

        public IntegralConfigService(IntegralConfigRepository integralConfigRepository)
        {
            _integralConfigRepository = integralConfigRepository;
        }

        /// <summary>
        /// 获取积分
        /// </summary>
        /// <returns></returns>
        public IntegralConfigDto Get()
        {
            var list = _integralConfigRepository.GetList();
            var integral = new IntegralConfigDto
            {
                Recharge = 0,
                Consumption = 0,
                Everyday = 0
            };
            var everyday = list.FirstOrDefault(a => a.Type == (int)IntegralType.EverydayLogin);
            if (everyday != null)
            {
                integral.Everyday = everyday.Integral;
            }
            var recharge = list.FirstOrDefault(a => a.Type == (int)IntegralType.Recharge);
            if (recharge != null)
            {
                integral.Recharge = recharge.Integral;
            }
            var consumption = list.FirstOrDefault(a => a.Type == (int)IntegralType.Consumption);
            if (consumption != null)
            {
                integral.Consumption = consumption.Integral;
            }
            return integral;
        }

        /// <summary>
        /// 保存积分
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult Save(IntegralConfigDto model)
        {
            var result = new TResult();
            var list = _integralConfigRepository.GetList();
            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    SaveEverydayLogin(model, list);
                    SaveRecharge(model, list);
                    SaveConsumption(model, list);
                    _integralConfigRepository.SaveChanges();
                    tran.Complete();
                }
                return result.SuccessResult();
            }
            catch (Exception e)
            {
                //Logger.Info("微信会员积分保存失败:" + e.Message);
                return result.FailureResult();
            }
        }

        /// <summary>
        /// 获取积分配置
        /// </summary>
        /// <returns></returns>
        public List<Tbl_IntegralConfig> GetList()
        {
            var list = _integralConfigRepository.GetList();
            return list;
        }


        /// <summary>
        /// 保存消费积分设置
        /// </summary>
        /// <param name="model"></param>
        /// <param name="list"></param>
        private void SaveConsumption(IntegralConfigDto model, List<Tbl_IntegralConfig> list)
        {
            var consumption = list.FirstOrDefault(a => a.Type == (int)IntegralType.Consumption);
            if (consumption != null)
            {
                consumption.Integral = model.Consumption;
                _integralConfigRepository.Update(consumption);
            }
            else
            {
                _integralConfigRepository.Add(new Tbl_IntegralConfig
                {
                    Integral = model.Consumption,
                    Type = (int)IntegralType.Consumption,
                    Name = "每消费1元"
                });
            }
        }

        /// <summary>
        /// 保存充值积分设置
        /// </summary>
        /// <param name="model"></param>
        /// <param name="list"></param>
        private void SaveRecharge(IntegralConfigDto model, List<Tbl_IntegralConfig> list)
        {
            var recharge = list.FirstOrDefault(a => a.Type == (int)IntegralType.Recharge);
            if (recharge != null)
            {
                recharge.Integral = model.Recharge;
                _integralConfigRepository.Update(recharge);
            }
            else
            {
                _integralConfigRepository.Add(new Tbl_IntegralConfig
                {
                    Integral = model.Recharge,
                    Type = (int)IntegralType.Recharge,
                    Name = "每充值1元"
                });
            }
        }
        /// <summary>
        /// 保存登录积分设置
        /// </summary>
        /// <param name="model"></param>
        /// <param name="list"></param>
        private void SaveEverydayLogin(IntegralConfigDto model, List<Tbl_IntegralConfig> list)
        {
            var everyday = list.FirstOrDefault(a => a.Type == (int)IntegralType.EverydayLogin);
            if (everyday != null)
            {
                everyday.Integral = model.Everyday;
                _integralConfigRepository.Update(everyday);
            }
            else
            {
                _integralConfigRepository.Add(new Tbl_IntegralConfig
                {
                    Integral = model.Everyday,
                    Type = (int)IntegralType.EverydayLogin,
                    Name = "每天第一次登录"
                });
            }
        }
    }
}
