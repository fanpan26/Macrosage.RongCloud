using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Macrosage.RongCloud.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFileName = AppDomain.CurrentDomain.BaseDirectory + "log4net.config";
            log4net.Config.XmlConfigurator.Configure(new FileInfo(configFileName));
            ILog log = LogManager.GetLogger(typeof(Program));

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

            log.Info("正在发送弹幕消息");
            service.SendChatRoomMessageAsync(new ScreenTextRongCloudMessage
            {
                ChatRoomId = "1497235996977",
                Content = new { cv = 131276, name = "盘子", txt = "哈哈哈哈" },
                SendUserId = "131276"
            });
            log.Info("已经发送");

            Console.Read();

        }
    }
}
