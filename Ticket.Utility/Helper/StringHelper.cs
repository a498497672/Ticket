using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Utility.Helper
{
    public class StringHelper
    {
        /// <summary> 
        /// 数字随机数 
        /// </summary>
        /// <param name="n">长度</param> 
        public static string RandNum(int len)
        {
            char[] arrChar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < len; i++)
            {
                num.Append(arrChar[rnd.Next(0, 9)].ToString());
            }
            return num.ToString();
        }
    }
}
