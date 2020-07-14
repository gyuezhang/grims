using MySql.Data.MySqlClient;
using System;

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
    }
}
