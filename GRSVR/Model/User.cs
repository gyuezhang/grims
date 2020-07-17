using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRSVR
{
    public class User
    {
        public int id { get; set; }
        public int deptid { get; set; }
        public string name { get; set; }
        public string passwd { get; set; }
        public DateTime birthday { get; set; }
        public bool sex { get; set; }
        public int avator { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string remark { get; set; }
    }
}
