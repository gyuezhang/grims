using MySql.Data.MySqlClient;
using System;

namespace GRSVR
{
    public class GRDbTabWell
    {
        public static void InitTab()
        {
            GRDb.Exec("create table if not exists grims.well( " +
                   "id int auto_increment,                 " +          //0
                   "tsorst bigint not null,                   " +          //1
                   "village bigint not null,                  " +          //2
                   "unitcat varchar(255),                  " +          //3
                   "loc varchar(255),                      " +          //4
                   "lng float,                            " +    //5
                   "lat float,                            " +    //6
                   "usefor varchar(255),                   " +          //7
                   "digtime date,                  " +                  //8
                   "welldepth float,                     " +            //9
                   "tubemat varchar(255),          " +                  //10
                   "tubeir float,                         " +           //11
                   "stanwaterdepth float,                  " +          //12
                   "saltwaterfloordepth float,            " +           //13
                   "filterloclow float,                    " +          //14
                   "filterlochigh float,               " +              //15
                   "stillwaterloc float,                      " +       //16
                   "pumpmode varchar(255),                     " +      //17
                   "pumppower float,                     " +            //18
                   "coverarea float,                " +                 //19
                   "suppeoplenum int,                       " +         //20
                   "iswaterlevelop bool,                       " +      //21
                   "ismfinstalled bool,                       " +       //22
                   "linkwellno int,                      " +            //23
                   "isseepchnlinked bool,                   " +         //24
                   "seepchnlength float,                 " +            //25
                   "remark varchar(255),                " +             //26
                   "primary key(Id),                        " +
                   "foreign key(tsorst) references grims.areacode(code)," +
                   "foreign key(village) references grims.areacode(code)" +
                   ")default charset = utf8mb4; ");
        }
    }
}
