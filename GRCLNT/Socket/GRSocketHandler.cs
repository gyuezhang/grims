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

        public delegate void LoginEventHandler(ApiRes state);
        public static event LoginEventHandler login;
        public static void OnLogin(GRSocketStringPackageInfo request)
        {
            login(request.resState);
        }

        public delegate void AddDeptEventHandler(ApiRes state);
        public static event AddDeptEventHandler addDept;
        public static void OnAddDept(GRSocketStringPackageInfo request)
        {
            addDept(request.resState);
        }

        public delegate void DelDeptEventHandler(ApiRes state);
        public static event DelDeptEventHandler delDept;
        public static void OnDelDept(GRSocketStringPackageInfo request)
        {
            delDept(request.resState);
        }

        public delegate void EdtDeptEventHandler(ApiRes state);
        public static event EdtDeptEventHandler edtDept;
        public static void OnEdtDept(GRSocketStringPackageInfo request)
        {
            edtDept(request.resState);
        }

        public delegate void GetDeptsEventHandler(ApiRes state, List<Dept> depts);
        public static event GetDeptsEventHandler getDepts;
        public static void OnGetDepts(GRSocketStringPackageInfo request)
        {
            getDepts(request.resState, JsonConvert.DeserializeObject<List<Dept>>(request.Parameters));
        }

        public delegate void AddUserEventHandler(ApiRes state);
        public static event AddUserEventHandler addUser;
        public static void OnAddUser(GRSocketStringPackageInfo request)
        {
            addUser(request.resState);
        }

        public delegate void DelUserEventHandler(ApiRes state);
        public static event DelUserEventHandler delUser;
        public static void OnDelUser(GRSocketStringPackageInfo request)
        {
            delUser(request.resState);
        }

        public delegate void EdtUserEventHandler(ApiRes state);
        public static event EdtUserEventHandler edtUser;
        public static void OnEdtUser(GRSocketStringPackageInfo request)
        {
            edtUser(request.resState);
        }

        public delegate void GetUsersEventHandler(ApiRes state, List<User> depts);
        public static event GetUsersEventHandler getUsers;
        public static void OnGetUsers(GRSocketStringPackageInfo request)
        {
            getUsers(request.resState, JsonConvert.DeserializeObject<List<User>>(request.Parameters));
        }

        public delegate void AddUserAuthorityEventHandler(ApiRes state);
        public static event AddUserAuthorityEventHandler addUserAuthority;
        public static void OnAddUserAuthority(GRSocketStringPackageInfo request)
        {
            addUserAuthority(request.resState);
        }

        public delegate void AddDeptAuthorityEventHandler(ApiRes state);
        public static event AddDeptAuthorityEventHandler addDeptAuthority;
        public static void OnAddDeptAuthority(GRSocketStringPackageInfo request)
        {
            addDeptAuthority(request.resState);
        }

        public delegate void DelAuthorityEventHandler(ApiRes state);
        public static event DelAuthorityEventHandler delAuthority;
        public static void OnDelAuthority(GRSocketStringPackageInfo request)
        {
            delAuthority(request.resState);
        }

        public delegate void GetDeptAuthoritiesEventHandler(ApiRes state);
        public static event GetDeptAuthoritiesEventHandler getDeptAuthorities;
        public static void OnGetDeptAuthorities(GRSocketStringPackageInfo request)
        {
            getDeptAuthorities(request.resState);
        }

        public delegate void GetUserAuthoritiesEventHandler(ApiRes state);
        public static event GetUserAuthoritiesEventHandler getUserAuthorities;
        public static void OnGetUserAuthorities(GRSocketStringPackageInfo request)
        {
            getUserAuthorities(request.resState);
        }
    }
}
