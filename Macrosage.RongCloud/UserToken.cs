using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    public class UserToken : RongCloudBaseResult
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
