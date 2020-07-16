using MySql.Data.MySqlClient;
using System;

namespace GRSVR
{
    public class GRDbTabLog
    {
        public static void InitTab()
        {
            GRDb.Exec("create table if not exists grims.log( " +
                      "id int auto_increment," +
                      "userid int ," +
                      "api varchar(128)," +
                      "level int," +
                      "ptime datetime," +
                      "ex varchar(255)," +
                      "primary key(id)) default charset=utf8mb4;");
        }
    }
}
