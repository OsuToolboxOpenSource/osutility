using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace OsuService.NetService
{
    public class OsuApiCore
    {
        /// <summary>
        /// 根据提供的参数，获取到网络提供的json数据
        /// </summary>
        /// <param name="url">网络地址</param>
        /// <param name="timeOut">超时限制（秒），默认为：5</param>
        /// <param name="getValues">网址后的GET参数列表，默认为：null</param>
        public string OsuApiCore(string url, int timeOut = 5, Dictionary<string, string> getValues = null)
        {
            string jsonString = null;

            //准备连接
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 1000 * timeOut;
            request.Method = "GET";

            //网址后的参数列表（如果有的话）
            if (getValues != null)
            {
                CookieCollection cookies = new CookieCollection();
                Cookie cookieTemp = new Cookie();
                foreach (var i in getValues)
                {
                    cookieTemp = new Cookie();
                    cookieTemp.Name = i.Key;
                    cookieTemp.Value = i.Value;

                    cookies.Add(cookieTemp);
                }

                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            jsonString = response.GetResponseStream().ToString();

            return jsonString;
        }


    }
}
