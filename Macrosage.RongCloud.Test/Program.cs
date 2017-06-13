using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            IRongCloudService service = new RongCloudService();
            ////获取用户token
            //var token = service.GetUserToken("100000");

            //Console.WriteLine(token?.Token);

            ////发送自定义消息类型
            //var result = service.SendChatRoomMessage(new ScreenTextRongCloudMessage
            //{
            //    ChatRoomId = "1497235996977",
            //    Content = new { cv = 131276, name = "盘子", txt = "哈哈哈哈" },
            //    SendUserId = "131276"
            //});

            service.SendChatRoomMessageAsync(new ScreenTextRongCloudMessage
            {
                ChatRoomId = "1497235996977",
                Content = new { cv = 131276, name = "盘子", txt = "哈哈哈哈" },
                SendUserId = "131276"
            });
            Console.WriteLine("已经发送");
          
            Console.Read();

        }
    }
}
