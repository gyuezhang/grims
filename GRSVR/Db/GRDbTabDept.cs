using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class GRDbTabDept
    {
        public static void InitTab()
        {
            GRDb.Exec("create table if not exists grims.dept(" +
                                                            "id int auto_increment," +
                                                            "name varchar(255) not null unique," +
                                                            "avator int," +
                                                            "remark varchar(512)," +
                                                            "primary key(id)," +
                                                            "foreign key(avator) references grims.file(id)" +
                                                            ") default charset=utf8mb4;");
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.dept;");
            if (QRes.Item1)
            {
                if (!QRes.Item2.HasRows)
                {
                    GRDb.Exec("insert into grims.dept (id,name,avator) values('-1','admin','-1');");
                }
            }
        }

        public static Tuple<bool, string> Add(Dept dept)
        {
            return GRDb.Exec("insert into grims.dept (deptname,avator,remark) values('" + dept.name + "','" + dept.avator + "','" + dept.remark + ");");
        }
        public static Tuple<bool, string> Del(int id)
        {
            return GRDb.Exec("delete from grims.dept where id='" + id + "';");
        }
        public static Tuple<bool, string> Edt(Dept dept)
        {
            return GRDb.Exec("update grims.dept set name='" + dept.name + "',avator='" + dept.avator + "',remark='" + dept.remark + "' where id='" + dept.id + "';");
        }
        public static Tuple<bool, List<Dept>, string> Get()
        {
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.dept;");
            if (!QRes.Item1)
                return new Tuple<bool, List<Dept>, string>(QRes.Item1, null, QRes.Item3);

            List<Dept> res = new List<Dept>();
            while (QRes.Item2.Read())
            {
                Dept tmpDept = new Dept();
                tmpDept.id = QRes.Item2.GetInt32("id");
                tmpDept.name = QRes.Item2.GetString("name");
                tmpDept.avator = QRes.Item2.GetInt32("avator");
                tmpDept.remark = QRes.Item2.GetString("remark");
                res.Add(tmpDept);
            }
            return new Tuple<bool, List<Dept>, string>(true, res, null);

        }
    }
}