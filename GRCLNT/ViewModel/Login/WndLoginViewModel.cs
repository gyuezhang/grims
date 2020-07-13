using MaterialDesignThemes.Wpf;
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
        public WndLoginViewModel()
        {
        }

        //UI Logic
        public int pageIndexBd { get; set; } = 0;
        public PackIconKind sysPackIconBd { 
            get 
            {
                return (pageIndexBd == 0) ? PackIconKind.Settings : PackIconKind.UndoVariant;
            }
            set
            {
                _ = (pageIndexBd == 0) ? PackIconKind.Settings : PackIconKind.UndoVariant; 
            }
        }
        public void SettingCmd()
        {
            pageIndexBd = pageIndexBd == 1?0:1;
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
