﻿using MySql.Data.MySqlClient;
using System;

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
    }
}
