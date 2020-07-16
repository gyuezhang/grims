using MySql.Data.MySqlClient;
using System;

namespace GRSVR
{
    public class GRDbTabAnm
    {
        public static void InitTab()
        {
            GRDb.Exec("create table if not exists grims.anm(" +
                                                   "id int auto_increment," +
                                                   "title varchar(255) not null," +
                                                   "Content varchar(1024)," +
                                                   "ctime datetime," +
                                                   "primary key(id)" +
                                                   ") default charset=utf8mb4;");
        }
    }
}
