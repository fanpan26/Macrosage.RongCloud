using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    public class RongCloudBaseResult
    {

        public RongCloudBaseResult() { }

        public int Code { get; set; }

        public bool Success { get { return Code == 200; } }

        public string ErrorMessage { get; set; }
    }
}
