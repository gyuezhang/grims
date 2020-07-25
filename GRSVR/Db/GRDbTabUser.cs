using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class GRDbTabUser
    {
        public static void InitTab()
        {
            GRDb.Exec("create table if not exists grims.user(" +
                                                   "id int auto_increment," +
                                                   "deptid int not null," +
                                                   "name varchar(255) not null unique," +
                                                   "pwd varchar(32) not null," +
                                                   "birthday date," +
                                                   "sex bool," +
                                                   "avator int," +
                                                   "email varchar(255)," +
                                                   "tel varchar(255)," +
                                                   "remark varchar(512)," +
                                                   "primary key(id)," +
                                                   "foreign key(deptid) references grims.dept(id)," +
                                                   "foreign key(avator) references grims.file(id)" +
                      ") default charset=utf8mb4;");
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.user;");
            if (QRes.Item1)
            {
                if (!QRes.Item2.HasRows)
                {
                    GRDb.Exec("insert into grims.user (id,deptid,name,pwd,avator) values('-1','-1','admin','" + Enc.GetMd5Hash("123456") + "','-1');");
                }
            }
        }

        public static Tuple<bool, string> AdminLogin(string pwd)
        {
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.user where id='-1';");
            if (!QRes.Item1)
                return new Tuple<bool, string>(QRes.Item1, QRes.Item3);

            QRes.Item2.Read();
            if (pwd == QRes.Item2.GetString("pwd"))
                return new Tuple<bool, string>(true, null);
            else
                return new Tuple<bool, string>(false, "ErrorPwd");
        }

        public static Tuple<bool, string> AdminResetPwd(string oldPwd, string newPwd)
        {
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.user where id = '-1';");
            if (!QRes.Item1)
                return new Tuple<bool, string>(QRes.Item1, QRes.Item3);

            QRes.Item2.Read();
            if (oldPwd == QRes.Item2.GetString("pwd"))
                return GRDb.Exec("update grims.user set pwd='" + newPwd + "' where id = '-1';");
            else
                return new Tuple<bool, string>(false, "ErrorPwd");
        }

        public static Tuple<bool, string> Add(User user)
        {
            int i = user.sex ? 0 : 1;
            string cmd = "insert into grims.user (deptid,name,pwd,birthday,sex,avator,email,tel,remark) values('" + user.deptid + "'" +
                    ",'" + user.name +
                    "','" + user.passwd +
                    "','" + user.birthday.Date +
                    "','" + i +
                    "','" + user.avator +
                    "','" + user.email +
                    "','" + user.tel +
                    "','" + user.remark +
                    "');";
            return GRDb.Exec(cmd);
        }

        public static Tuple<bool, string> Del(int id)
        {
            return GRDb.Exec("delete from grims.user where id='" + id.ToString() + "'");
        }

        public static Tuple<bool, string> Edt(User user)
        {
            return GRDb.Exec("update grims.user set deptid='" + user.deptid +
                "',name='" + user.name +
                "',pwd='" + user.passwd +
                "',birthday='" + user.birthday +
                "',sex='" + user.sex +
                "',avator='" + user.avator +
                "',email='" + user.email +
                "',tel='" + user.tel +
                "',remark='" + user.remark +
                "' where id='" + 
                user.id + "';");
        }

        public static Tuple<bool, List<User>, string> Get()
        {
            List<User> res = new List<User>();
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.user;");
            if (!QRes.Item1)
            {
                return new Tuple<bool, List<User>, string>(false, null, QRes.Item3);
            }

            while (QRes.Item2.Read())
            {
                User tmp = new User();
                tmp.id = QRes.Item2.GetInt32("id");
                tmp.deptid = QRes.Item2.GetInt32("deptid");
                tmp.name = QRes.Item2.GetString("name");
                tmp.passwd = QRes.Item2.GetString("pwd");
                tmp.birthday = QRes.Item2.GetDateTime("birthday");
                tmp.sex = QRes.Item2.GetBoolean("sex");
                tmp.avator = QRes.Item2.GetInt32("avator");
                tmp.email = QRes.Item2.GetString("email");
                tmp.tel = QRes.Item2.GetString("tel");
                tmp.remark = QRes.Item2.GetString("remark");
                res.Add(tmp);
            }
            return new Tuple<bool, List<User>, string>(true, res, null);
        }

        public static Tuple<bool, string> Login(string Name, string Pwd)
        {
            List<User> res = Get().Item2;
            foreach (User usr in res)
            {
                if (Name == usr.name && Pwd == usr.passwd)
                {
                    return new Tuple<bool, string>(true, null);
                }
            }
            return new Tuple<bool, string>(false, "ErrorPwd");
        }
    }
}
