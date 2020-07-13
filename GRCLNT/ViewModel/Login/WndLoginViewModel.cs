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
        private IWindowManager _windowManager;

        public WndLoginViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        //UI Logic
        public int pageIndexBd { get; set; } = 0;
        public string strName { get; set; }
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
            LoginSuccess();
            if (strName == "admin")
                OpenAdminMainViewModel();
            else
                OpenUserMainViewModel();
        }

        public void TestLinkCmd()
        {

        }

        //
        public void OpenUserMainViewModel()
        {
            var wndUserMainViewModel = new WndUserMainViewModel(_windowManager);
            this._windowManager.ShowWindow(wndUserMainViewModel);
            this.RequestClose();
        }
        public void OpenAdminMainViewModel()
        {
            var wndAdminMainViewModel = new WndAdminMainViewModel(_windowManager);
            this._windowManager.ShowWindow(wndAdminMainViewModel);
            this.RequestClose();
        }


        public MCfg cfgBd { get; set; } = Cfg.Get();

        public void LoginSuccess()
        {
            Cfg.Set(cfgBd);
        }
    }
}
