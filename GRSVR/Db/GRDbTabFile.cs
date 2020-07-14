using MySql.Data.MySqlClient;
using System;

namespace GRSVR
{
    public class GRDbTabFile
    {
        public static void InitTab()
        {
            GRDb.Exec("create table if not exists grims.file(" +
                                                   "id int auto_increment," +
                                                   "md5 varchar(255) not null unique," +
                                                   "name varchar(255)," +
                                                   "path varchar(512)," +
                                                   "size int," +
                                                   "type int," +    /*0:avator 1:*/
                                                   "primary key(id)" +
                                                   ") default charset=utf8mb4;");
        }
    }
}
