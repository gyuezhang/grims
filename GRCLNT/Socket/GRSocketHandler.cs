using System.Collections.Generic;
using Newtonsoft.Json;

namespace GRCLNT
{
    public class GRSocketHandler
    {
        //CONN
        public delegate void ConnStateEventHandler(ApiRes state);
        public static event ConnStateEventHandler ConnState;
        public static void OnConnState(GRSocketStringPackageInfo request)
        {
            ConnState(request.resState);
        }

        //ADMIN
        public delegate void AdminLoginEventHandler(ApiRes state);
        public static event AdminLoginEventHandler adminLogin;
        public static void OnAdminLogin(GRSocketStringPackageInfo request)
        {
            adminLogin(request.resState);
        }

        public delegate void AdminResetPwdEventHandler(ApiRes state);
        public static event AdminResetPwdEventHandler adminResetPwd;
        public static void OnAdminResetPwd(GRSocketStringPackageInfo request)
        {
            adminResetPwd(request.resState);
        }
    }
}
