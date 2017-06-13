using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    public interface IRongCloudService
    {
        /// <summary>
        /// 获取用户Token
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="name">用户名</param>
        /// <param name="portraitUri">用户头像</param>
        /// <returns></returns>
        UserToken GetUserToken(string userId, string name = "", string portraitUri = "");

        /// <summary>
        /// 发送聊天室信息
        /// </summary>
        /// <param name="sendUserId">发送者用户名</param>
        /// <param name="chatRoomId">聊天室ID</param>
        /// <param name="objectName">自定义聊天类型</param>
        /// <param name="content">发送信息内容，toJson 或者消息实体</param>
        /// <returns></returns>
        RongCloudBaseResult SendChatRoomMessage(RongCloudMessage message);

        /// <summary>
        /// 发送聊天室信息 但是异步发送，并无返回值
        /// </summary>
        /// <param name="sendUserId">发送者用户名</param>
        /// <param name="chatRoomId">聊天室ID</param>
        /// <param name="objectName">自定义聊天类型</param>
        /// <param name="content">发送信息内容，toJson 或者消息实体</param>
        /// <returns></returns>
        void SendChatRoomMessageAsync(RongCloudMessage message);


    }
}
