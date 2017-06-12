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
            for (var i = 0; i < 100; i++)
            {
                UserToken userToken = RequestUtility.ExecutePost<UserToken>("/user/getToken.json", new Dictionary<string, object> {
                { "userId","100000"},
                { "name1","xiaopanzi"},
                { "portraitUri",""}
            });

                if (!userToken.Success)
                {
                    Console.WriteLine(userToken.Code);
                    Console.Write(userToken.ErrorMessage);
                }
                else
                {
                    Console.WriteLine(userToken.token);
                }
            }


            Console.Read();

        }
    }
}
