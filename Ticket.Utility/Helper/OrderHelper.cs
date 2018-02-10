using System;
using System.Threading;

namespace Ticket.Utility.Helper
{
    public sealed class OrderHelper
    {
        private static readonly object Locker = new object();
        private static int _sn;

        /// <summary>
        /// 生成订单编号
        /// （设置为20位，时间（17）+数字（3）），
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderNo()
        {
            lock (Locker)  //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            {
                if (_sn == 99)
                {
                    _sn = 0;
                }
                else
                {
                    _sn++;
                }
                Thread.Sleep(50);
                string result = DateTime.Now.ToString("yyyyMMddHHmmssfff") + _sn.ToString().PadLeft(3, '0');
                return result.Substring(2, result.Length - 2);
            }
        }
    }
}
