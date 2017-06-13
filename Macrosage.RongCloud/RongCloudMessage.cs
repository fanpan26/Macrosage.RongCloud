using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    public abstract class RongCloudMessage
    {
        public string SendUserId { get; set; }
        public string ChatRoomId { get; set; }
        public virtual string ObjectName { get; }
        public virtual object Content { get; set; } 
    }

    public class ScreenTextRongCloudMessage : RongCloudMessage
    {
        public override string ObjectName
        {
            get
            {
                return "A:ScreenText";
            }
        }
    }
}
