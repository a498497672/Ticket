using System.Web;

namespace Ticket.Utility.Helper
{
    public class ClientIpHelper
    {
        /// <summary>
        /// 获取客户端的内网IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetInnerIp()
        {
            string innerIP = GetPublicNetworkIp();
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                try
                {
                    innerIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0].Trim();
                }
                catch
                {
                    innerIP = "0.0.0.0";
                }
            }

            return innerIP;
        }

        /// <summary>
        /// 获取客户端的公网IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetPublicNetworkIp()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
    }
}
