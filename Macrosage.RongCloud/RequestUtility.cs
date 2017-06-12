using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    public class RequestUtility
    {
        private static readonly object _lock = new object();

        private static readonly string _baseRongCloudUri = "http://api.cn.ronghub.com";

        private static RestClient _client;
        private static RestClient Client
        {
            get
            {
                if (_client == null)
                {
                    lock (_lock)
                    {
                        if (_client == null)
                        {
                            _client = new RestClient(_baseRongCloudUri);
                            _client.AddDefaultHeader("App-Key", RongCloudConfig.AppKey);
                        }
                    }
                }
                return _client;
            }
        }


        private static IRestRequest PrapareRequest(string url, Method method, IDictionary<string, object> parameter = null)
        {
            IRestRequest request = new RestRequest(url);
            request.Method = method;

            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            request.AddRongCloudHeader();

            if (parameter?.Count() > 0)
            {
                foreach (KeyValuePair<string, object> kv in parameter)
                {
                    if (method == Method.GET)
                    {
                        request.AddQueryParameter(kv.Key, WebUtility.UrlEncode(kv.Value.ToString()));
                    }

                    if (method == Method.POST)
                    {
                        request.AddParameter(new Parameter() { Name = kv.Key, Value = WebUtility.UrlEncode(kv.Value.ToString()), Type = ParameterType.GetOrPost });
                    }
                }
            }
            return request;
        }


        #region 获取请求结果 返回string
        private static string Execute(string url, Method method, IDictionary<string, object> parameter = null)
        {

            IRestRequest request = PrapareRequest(url, method, parameter);
          
            IRestResponse response = Client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //记录日志
                Console.WriteLine(response.StatusDescription);
            }
            return response.Content;
        }

        public static string ExecuteGet(string url, IDictionary<string, object> parameter = null)
        {
            return Execute(url, Method.GET, parameter);
        }

        public static string ExecutePost(string url, IDictionary<string, object> parameter = null)
        {
            return Execute(url, Method.POST, parameter);
        }
        #endregion

        #region 获取请求结果，返回T
        private static T Execute<T>(string url, Method method, IDictionary<string, object> parameter = null) where T : RongCloudBaseResult, new()
        {
            IRestRequest request = PrapareRequest(url, method, parameter);

            IRestResponse<T> response = Client.Execute<T>(request);

            if (response.Data.Code != 200)
            {
                Console.WriteLine(RongCloudStateCode.GetErrorMessage(response.Data.Code));
            }

            return response.Data;
        }

        public static T ExecuteGet<T>(string url, IDictionary<string, object> parameter = null) where T: RongCloudBaseResult, new()
        {
            return Execute<T>(url, Method.GET, parameter);
        }

        public static T ExecutePost<T>(string url, IDictionary<string, object> parameter = null) where T: RongCloudBaseResult, new()
        {
            return Execute<T>(url, Method.POST, parameter);
        }
        #endregion

        #region 不需要返回结果，只需要异步执行，并记录
        private static void ExecuteAsync(string url, Method method, IDictionary<string, object> parameter = null)
        {
            IRestRequest request = PrapareRequest(url, method, parameter);

            RestRequestAsyncHandle handle = Client.ExecuteAsync(request, response =>
             {
                 Console.WriteLine(response.StatusCode);
                 Console.WriteLine(response.Content);
             });
        }

        public static void ExecuteAsyncGet(string url, IDictionary<string, object> parameter = null)
        {
             ExecuteAsync(url, Method.GET, parameter);
        }

        public static void ExecuteAsyncPost(string url, IDictionary<string, object> parameter = null)
        {
            ExecuteAsync(url, Method.POST, parameter);
        }
        #endregion
    }
}
