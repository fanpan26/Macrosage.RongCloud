using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    internal sealed class RongCloudApi
    {
        /// <summary>
        /// 获取用户Token接口
        /// </summary>
        public static readonly string Api_GetUserToken = "/user/getToken.json";
        /// <summary>
        /// 创建聊天室接口
        /// </summary>
        public static readonly string Api_CreateChatRoom = "/chatroom/create.json";

        /// <summary>
        /// 发送聊天消息接口
        /// </summary>
        public static readonly string Api_SendChatRoomMessage = "/message/chatroom/publish.json";

        /// <summary>
        /// 刷新用户信息
        /// </summary>
        public static readonly string Api_RefreshUser = "/user/refresh";

        /// <summary>
        /// 检测用户是否在线
        /// </summary>
        public static readonly string Api_CheckUserOnline = "/user/checkOnline";
    }
}
