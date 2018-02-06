using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml;
using Ticket.Infrastructure.Sms.Response;

namespace Ticket.Infrastructure.Sms.Core
{
    public class SmsManage
    {
        /// <summary>
        /// 发生短信
        /// </summary>
        /// <param name="phoneList">手机号码</param>
        /// <param name="msg">内容</param>
        /// <returns></returns>
        public SmsResponse Send(string phoneList, string content)
        {
            string userName = "ticket";
            string passWord = "123456q";
            string str4 = "12";
            string str5 = "";
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            string str8 = Encoding.UTF8.GetString(bytes);
            string resultText = PostData("uc=" + userName + "&pwd=" + passWord + "&cont=" + str8 + "&callee=" + phoneList + "&msgid=" + str4 + "&otime=" + str5);
            var result = ResultStatus(resultText);
            BalanceInsufficient(result);
            return result;
        }

        // Methods
        private string PostData(string str)
        {
            string requestUriString = "http://webservice.hctcom.com/service.asmx/SendSMS?";
            try
            {
                byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(str);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
                request.Timeout = 0x7530;
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("GB2312");
                StreamReader reader = new StreamReader(responseStream, encoding);
                char[] buffer = new char[0x100];
                int length = reader.Read(buffer, 0, 0x100);
                StringBuilder builder = new StringBuilder("");
                while (length > 0)
                {
                    string temp = new string(buffer, 0, length);
                    builder.Append(temp);
                    length = reader.Read(buffer, 0, 0x100);
                }
                response.Close();
                reader.Close();
                XmlDocument document = new XmlDocument();
                document.LoadXml(builder.ToString());
                return document.SelectSingleNode(".").InnerText;
            }
            catch (Exception)
            {
                return "-00";//发送失败.
            }
        }

        /// <summary>
        /// 返回短信状态
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static SmsResponse ResultStatus(string text)
        {
            var result = new SmsResponse
            {
                Success = false,
                Message = "发送失败"
            };
            switch (text)
            {
                case "-00":
                    result.Message = "发送失败";
                    break;

                case "-01":
                    result.Message = "短信功能余额不足";
                    break;

                case "-02":
                    result.Message = "用户错误";
                    break;

                case "-03":
                    result.Message = "密码错误";
                    break;

                case "-04":
                    result.Message = "传入参数不合法、超长、类型错误";
                    break;

                case "-09":
                    result.Message = "暂停服务";
                    break;

                case "-12":
                    result.Message = "接口错误";
                    break;

                case "-13":
                    result.Message = "装载错误";
                    break;

                case "-19":
                    result.Message = "由于预算数据没有配置，预算返回失败，提示主叫“被叫无法接通";
                    break;

                case "-25":
                    result.Message = "参数不合法";
                    break;

                case "-26":
                    result.Message = "会议人数大于系统级配置值";
                    break;

                case "-29":
                    result.Message = "呼叫不存在";
                    break;

                case "-30":
                    result.Message = "会议不存在";
                    break;

                case "-31":
                    result.Message = "UC号码非指定会场主持人";
                    break;

                case "-33":
                    result.Message = "UC号码非发起CTD号码";
                    break;

                case "-34":
                    result.Message = "主持人UC号码不存在";
                    break;

                case "-35":
                    result.Message = "该与会者号码不在会议中";
                    break;

                case "-36":
                    result.Message = "事务正忙，不允许进行该操作";
                    break;

                case "-37":
                    result.Message = "会议不存在或会议尚未结束";
                    break;

                case "-38":
                    result.Message = "已经在录音，无需再启动";
                    break;

                case "-39":
                    result.Message = "已经停止录音，无需再停止";
                    break;

                case "-40":
                    result.Message = "该用户没有会议列表";
                    break;

                case "-41":
                    result.Message = "已经在播放背景音，无需再启动";
                    break;

                case "-42":
                    result.Message = "已经在停止背景音，无需再停止";
                    break;

                case "-45":
                    result.Message = "随机数字段长度不合法，或随机字符串无法转成Long型";
                    break;

                case "-43":
                    result.Message = "无需修改听说权";
                    break;

                case "-44":
                    result.Message = "主持人不能修改听说权";
                    break;

                case "-46":
                    result.Message = "CTC主持人类型不正确";
                    break;

                case "-47":
                    result.Message = "用户状态不正确（非激活状态）";
                    break;

                case "-48":
                    result.Message = "主持人不能被踢出";
                    break;

                case "-49":
                    result.Message = "主叫号码或UC号码输入过长";
                    break;

                case "-50":
                    result.Message = "被叫号码或目的号码输入过长";
                    break;

                case "-78":
                    result.Message = "该UC号码无权Web接入（未用）";
                    break;

                case "-84":
                    result.Message = "短信群发超过群发允许的上限";
                    break;

                case "-85":
                    result.Message = "超过短信群发的日最大条数限制";
                    break;

                case "-86":
                    result.Message = "超过短信群发的月最大条数限制";
                    break;

                case "-99":
                    result.Message = "操作频繁";
                    break;

                case "-103":
                    result.Message = "没有订阅传真功能";
                    break;

                default:
                    result.Success = true;
                    result.Message = "发送成功";
                    break;
            }
            return result;
        }

        private string SendEmail(string sendEmail, string subject, string strBody, string filePath)
        {
            try
            {
                string address = "zhly_demo@fengjing.com";
                string password = "fjzl0617";
                string host = "smtp.fengjing.com";
                string mailPort = "25";
                MailMessage message = new MailMessage();
                message.From = new MailAddress(address);
                message.To.Add(new MailAddress(sendEmail));
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = strBody;
                message.BodyEncoding = Encoding.UTF8;
                if ((filePath != null) && (filePath != ""))
                {
                    Attachment item = new Attachment(filePath);
                    message.Attachments.Add(item);
                }
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Host = host;
                client.Port = int.Parse(mailPort);
                if ((password != null) && (password != ""))
                {
                    client.Credentials = new NetworkCredential(address, password);
                }
                else
                {
                    client.Credentials = new NetworkCredential("zhly_demo@fengjing.com", "fjzl0617");
                }
                client.Send(message);
                return "发送成功";
            }
            catch (Exception)
            {
                return "发送失败";
            }
        }

        /// <summary>
        /// 短信功能余额不足发送短信提醒
        /// </summary>
        /// <param name="smsResponse"></param>
        public void BalanceInsufficient(SmsResponse smsResponse)
        {
            string sendEmail = "chenb@fengjing.com";
            if (smsResponse.Message == "短信功能余额不足")
            {
                SendEmail(sendEmail, "【短信发送功能】", smsResponse.Message, "");
            }
        }
    }
}
