using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    public class RongCloudService : IRongCloudService
    {
        public UserToken GetUserToken(string userId, string name = "", string portraitUri = "")
        {
            var parameter = new Dictionary<string, object> {
                { "userId",userId},
                { "name",name},
                { "portraitUri",portraitUri}
            };
            return RequestUtility.ExecutePost<UserToken>(RongCloudApi.Api_GetUserToken, parameter);
        }

      

        public RongCloudBaseResult SendChatRoomMessage(RongCloudMessage message)
        {
            var parameter = BuildChatRoomMessageParameter(message);
            return RequestUtility.ExecutePost<RongCloudBaseResult>(RongCloudApi.Api_SendChatRoomMessage, parameter);
        }

        public void SendChatRoomMessageAsync(RongCloudMessage message)
        {
            var parameter = BuildChatRoomMessageParameter(message);
            RequestUtility.ExecuteAsyncPost(RongCloudApi.Api_SendChatRoomMessage, parameter);
        }
        private IDictionary<string, object> BuildChatRoomMessageParameter(RongCloudMessage message)
        {
            string jsonBody = string.Empty;

            if (message.Content.GetType().Name == "String")
            {
                jsonBody = message.Content.ToString();
            }
            else
            {
                jsonBody = message.Content.ToJson();
            }
            var parameter = new Dictionary<string, object>
            {
                { "fromUserId",message.SendUserId},
                { "toChatroomId",message.ChatRoomId},
                { "objectName",message.ObjectName},
                { "content",jsonBody}
            };
            return parameter;
        }
    }
}
