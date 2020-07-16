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
            Tuple<bool, MySqlDataReader, string> QRes = GRDb.Query("select * from grims.file;");
            if (QRes.Item1)
            {
                if (!QRes.Item2.HasRows)
                {
                    GRDb.Exec("insert into grims.file (id,md5) values('-1','" + Enc.GetMd5Hash("0") + "');");
                }
            }
        }
    }
}
