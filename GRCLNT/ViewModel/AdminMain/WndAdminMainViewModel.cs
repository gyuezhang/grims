﻿using MaterialDesignThemes.Wpf;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GRCLNT
{
    public class WndAdminMainViewModel : Screen
    {
        private IWindowManager _windowManager;

        public WndAdminMainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;

            //重置最大窗口尺寸（此处避免运行过程中任务栏显隐）
            maxHeightBd = SystemParameters.WorkArea.Height + 7;
            maxWidthBd = SystemParameters.WorkArea.Width + 7;
        }


        public double maxHeightBd { get; set; } = SystemParameters.WorkArea.Height + 7;
        public double maxWidthBd { get; set; } = SystemParameters.WorkArea.Width + 7;
        public WindowState windowStateBd { get; set; }
        public Thickness marginBd { get; set; } = new Thickness(0, 0, 0, 0);
        public Visibility dragImgVisibilityBd { get; set; } = Visibility.Visible;
        public Visibility menuBtnVisibilityBd { get; set; } = Visibility.Visible;
        public int menuBtnIndexBd { get; set; } = 1;
        public Visibility settingBtnVisibilityBd { get; set; } = Visibility.Hidden;
        public Screen mainVmBd { get; set; }
       // public CtrlAddrsBarViewModel addrsBarVmBd { get; set; }
        public SnackbarMessageQueue messageQueueBd { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(1.2));
        public void StateChangedCmd()
        {
            //重置最大窗口尺寸（此处避免运行过程中任务栏显隐）
            maxHeightBd = SystemParameters.WorkArea.Height + 7;
            maxWidthBd = SystemParameters.WorkArea.Width + 7;
            marginBd = (windowStateBd == WindowState.Maximized) ? new Thickness(7, 7, 0, 0) : new Thickness(0, 0, 0, 0);
            dragImgVisibilityBd = (windowStateBd != WindowState.Maximized) ? Visibility.Visible : Visibility.Hidden;
        }

        public void QuitCmd()
        {
            this.RequestClose();
        }

        public void MenuBtnCmd(string cmdPara)
        {
            SelectPage((E_Page)Enum.Parse(typeof(E_Page), cmdPara, true));
        }

        public void SelectPage(E_Page p)
        {
            menuBtnVisibilityBd = Visibility.Visible;
            settingBtnVisibilityBd = Visibility.Hidden;
            switch (p)
            {
                case E_Page.Dashboard:
                    menuBtnIndexBd = 1;
                    mainVmBd = new PageAdminDashboardViewModel(this);
                    break;
                case E_Page.GroupMng:
                    menuBtnIndexBd = 3;
                    mainVmBd = new PageAdminGroupMngViewModel(this);
                    break;
                case E_Page.LogMng:
                    menuBtnIndexBd = 5;
                    mainVmBd = new PageAdminLogMngViewModel(this);
                    break;
                case E_Page.AnmMng:
                    menuBtnIndexBd = 7;
                    mainVmBd = new PageAdminAnmMngViewModel(this);
                    break;
                case E_Page.Setting:
                    menuBtnVisibilityBd = Visibility.Hidden;
                    settingBtnVisibilityBd = Visibility.Visible;
                    mainVmBd = new PageAdminSettingViewModel(this);
                    break;
                default:
                    break;
            }
        }
    }
}
