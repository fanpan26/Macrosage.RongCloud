using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    internal class RongCloudStateCode
    {
        private static IReadOnlyDictionary<int, string> readonlyDictionary = new Dictionary<int, string>
        {
            { 1000,"服务器端内部逻辑错误,请稍后重试"},
            { 1001,"App Key 与 App Secret 不匹配"},
            { 1002,"参数错误"},
            { 1003,"没有 POST 任何数据"},
            { 1004,"验证签名错误"},
            { 1005,"参数长度超限"},
            { 1006,"App 被锁定或删除"},
            { 1007,"该方法被限制调用"},
            { 1008,"调用频率超限"},
            { 1009,"服务未开通"},
            { 1015,"要删除的保活聊天室 ID 不存在。"},
            { 1016,"设置的保活聊天室个数超限。"},
            { 1050,"内部服务响应超时"},
            { 2007,"测试用户数量超限"}

        };

        public static string GetErrorMessage(int code)
        {
            if (readonlyDictionary.ContainsKey(code))
            {
                return readonlyDictionary[code];
            }
            return $"未知错误:{code}";
        }
    }
}
