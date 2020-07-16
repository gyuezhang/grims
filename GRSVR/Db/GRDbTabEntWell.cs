using MySql.Data.MySqlClient;
using System;

namespace GRSVR
{
    public class GRDbTabEntWell
    {
        public static void InitTab()
        {

            GRDb.Exec("create table if not exists grims.entwell( " +
                       "id int auto_increment,                 " +             //0
                       "tsorst bigint not null,                   " +             //1
                       "entname varchar(255),                  " +             //2
                       "unitcat varchar(255),                  " +             //3
                       "loc varchar(255),                      " +             //4
                       "lng float,                            " +       //5
                       "lat float,                            " +       //6
                       "usefor varchar(255),                   " +             //7
                       "digtime date,                  " +                     //8
                       "fetchWaterid varchar(255),         " +                 //9
                       "ispaid bool,         " +                               //10
                       "welldepth float,                     " +               //11
                       "tubemat varchar(255),          " +                     //12
                       "tubeir float,                         " +              //13
                       "stanwaterdepth float,                  " +             //14
                       "saltwaterfloordepth float,            " +              //15
                       "filterloclow float,                    " +             //16
                       "filterlochigh float,               " +                 //17
                       "stillwaterloc float,                      " +          //18
                       "pumpmode varchar(255),                     " +         //19
                       "pumppower float,                     " +               //20
                       "iswaterlevelop bool,                       " +         //21
                       "ismfinstalled bool,                       " +          //22
                       "remark varchar(255),                " +                //23
                       "primary key(Id),                        " +
                       "foreign key(tsorst) references grims.areacode(code)" +
                   ")default charset = utf8mb4; ");
        }
    }
}
