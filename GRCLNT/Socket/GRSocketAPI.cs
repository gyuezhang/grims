using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GRCLNT
{
    public class GRSocketAPI
    {
        public static void AdminLogin(string pwd)
        {
            GRSocket.Send(ApiId.AdminLogin, JsonConvert.SerializeObject(pwd));
        }
        public static void AdminResetPwd(string oldPwd, string newPwd)
        {
            GRSocket.Send(ApiId.AdminResetPwd, JsonConvert.SerializeObject(new Tuple<string, string>(oldPwd, newPwd)));
        }
    }
}
