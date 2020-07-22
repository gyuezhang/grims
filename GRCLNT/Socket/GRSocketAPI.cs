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
        public static void Login(string name,string pwd)
        {
            GRSocket.Send(ApiId.Login, JsonConvert.SerializeObject(new Tuple<string, string>(name,pwd)));
        }
        public static void AddDept(Dept dept)
        {
            GRSocket.Send(ApiId.AddDept, JsonConvert.SerializeObject(dept));
        }
        public static void DelDept(int id)
        {
            GRSocket.Send(ApiId.DelDept, JsonConvert.SerializeObject(id));
        }
        public static void EdtDept(Dept dept)
        {
            GRSocket.Send(ApiId.EdtDept, JsonConvert.SerializeObject(dept));
        }
        public static void GetDepts()
        {
            GRSocket.Send(ApiId.GetDepts, null);
        }
        public static void AddUser(User user)
        {
            GRSocket.Send(ApiId.AddUser, JsonConvert.SerializeObject(user));
        }
        public static void DelUser(int id)
        {
            GRSocket.Send(ApiId.DelUser, JsonConvert.SerializeObject(id));
        }
        public static void EdtUser(User user)
        {
            GRSocket.Send(ApiId.EdtUser, JsonConvert.SerializeObject(user));
        }
        public static void GetUsers()
        {
            GRSocket.Send(ApiId.GetUsers, null);
        }
        public static void AddDeptAuthority(Authority auth)
        {
            GRSocket.Send(ApiId.AddDeptAuthority, JsonConvert.SerializeObject(auth));
        }
        public static void AddUserAuthority(Authority auth)
        {
            GRSocket.Send(ApiId.AddUserAuthority, JsonConvert.SerializeObject(auth));
        }
        public static void DelAuthority(int id)
        {
            GRSocket.Send(ApiId.DelAuthority, JsonConvert.SerializeObject(id));
        }
        public static void GetDeptAuthorities()
        {
            GRSocket.Send(ApiId.GetDeptAuthorities, null);
        }
        public static void GetUserAuthorities()
        {
            GRSocket.Send(ApiId.GetUserAuthorities, null);
        }
    }
}
