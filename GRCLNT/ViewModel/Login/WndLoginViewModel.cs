using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public class WndLoginViewModel : Screen
    {
        //UI Logic
        public int pageIndexBd { get; set; } = 0;
        public bool CanSettingCmd => pageIndexBd == 0;
        public void SettingCmd()
        {
            pageIndexBd = 1;
        }
        public void BackCmd()
        {
            pageIndexBd = 0;
        }
        public void QuitCmd()
        {
            this.RequestClose();
        }

        //
        public void pwdChangedCmd()
        {

        }

        public void LoginCmd()
        {

        }

        public void TestLinkCmd()
        {

        }
    }
}
