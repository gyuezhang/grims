using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public enum Module
    {
        Well,
        EntWell,
        SediCtrl,
        GwDyna,
        GwProj,
        Hydro,
        Law,
    }

    public enum Auth
    {
        Add,
        Del,
        Edt,
        Get,
    }

    public class Authority
    {
        public int id { get; set; }
        public int userordeptid { get; set; }
        public Module module { get; set; }
        public Auth auth { get; set; }
    }
}
