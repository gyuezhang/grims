using MySql.Data.MySqlClient;
using System;

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
        }
    }
}
