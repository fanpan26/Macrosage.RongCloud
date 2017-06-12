using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud.Test
{
    public class UserToken : RongCloudBaseResult
    {
        public string userId { get; set; }
        public string token { get; set; }
    }
}
