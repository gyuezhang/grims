using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class GRDbTabAuthority
    {
        public static void InitTab()
        {
            GRDb.Exec("create table if not exists grims.authority(" +
                                                      "id int auto_increment," +
                                                      "userid int," +
                                                      "deptid int," +
                                                      "module int," +
                                                      "authority int," +
                                                      "primary key(id)," +
                                                      "foreign key(userid) references grims.user(id)," +
                                                      "foreign key(deptid) references grims.dept(id)" +
                                                      ") default charset=utf8mb4;");
        }

        public static Tuple<bool, string> AddUser(Authority authority)
        {
            string cmd = "insert into grims.authority (userid,deptid,module,authority) values('" + authority.userordeptid + "','0'" +
                    ",'" + authority.module +
                    "','" + authority.auth +
                    "');";
            return GRDb.Exec(cmd);
        }

        public static Tuple<bool, string> AddDept(Authority authority)
        {
            string cmd = "insert into grims.authority (userid,deptid,module,authority) values('0','" + authority.userordeptid + "'" +
                    ",'" + authority.module +
                    "','" + authority.auth +
                    "');";
            return GRDb.Exec(cmd);
        }

        public static Tuple<bool, string> Del(int id)
        {
            return GRDb.Exec("delete from grims.authority where id='" + id.ToString() + "'");
        }

        public static Tuple<bool, List<Authority>, string> GetDept()
        {
            List<Authority> res = new List<Authority>();
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.authority where deptid!='0';");
            if (!QRes.Item1)
            {
                return new Tuple<bool, List<Authority>, string>(false, null, QRes.Item3);
            }

            while (QRes.Item2.Read())
            {
                Authority tmp = new Authority();
                tmp.id = QRes.Item2.GetInt32("id");
                tmp.userordeptid = QRes.Item2.GetInt32("deptid");
                tmp.module = (Module)Enum.Parse(typeof(Module), QRes.Item2.GetInt32("module").ToString(),true);
                tmp.auth = (Auth)Enum.Parse(typeof(Auth), QRes.Item2.GetInt32("authority").ToString(), true);
                res.Add(tmp);
            }
            return new Tuple<bool, List<Authority>, string>(true, res, null);
        }

        public static Tuple<bool, List<Authority>, string> GetUser()
        {
            List<Authority> res = new List<Authority>();
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.authority where userid!='0';");
            if (!QRes.Item1)
            {
                return new Tuple<bool, List<Authority>, string>(false, null, QRes.Item3);
            }

            while (QRes.Item2.Read())
            {
                Authority tmp = new Authority();
                tmp.id = QRes.Item2.GetInt32("id");
                tmp.userordeptid = QRes.Item2.GetInt32("userid");
                tmp.module = (Module)Enum.Parse(typeof(Module), QRes.Item2.GetInt32("module").ToString(), true);
                tmp.auth = (Auth)Enum.Parse(typeof(Auth), QRes.Item2.GetInt32("authority").ToString(), true);
                res.Add(tmp);
            }
            return new Tuple<bool, List<Authority>, string>(true, res, null);
        }
    }
}
