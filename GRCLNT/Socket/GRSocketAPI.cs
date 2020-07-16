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
    }
}
