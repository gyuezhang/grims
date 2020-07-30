using System;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using Stylet;
using MaterialDesignThemes.Wpf;

namespace GRCLNT
{
    public class WndLoginViewModel : Screen
    {
        #region 初始化

        private IWindowManager _windowManager;

        public WndLoginViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;

            InitWidget();
            TryToLink();
            CheckAutoLogin();
        }

        private void InitWidget()
        {
            if (cfgBd.RecordPwd)
                curPwdBd = "11111111";
            else
                curPwdBd = "";
        }

        #endregion

        #region 属性

        public MCfg cfgBd { get; set; } = Cfg.Get();
        public string linkStateTextBd { get; set; }
        public Brush linkStateColorBd { get; set; }
        public int pageIndexBd { get; set; } = 0;
        public PackIconKind sysPackIconBd
        {
            get
            {
                return (pageIndexBd == 0) ? PackIconKind.Settings : PackIconKind.UndoVariant;
            }
            set
            {
                _ = (pageIndexBd == 0) ? PackIconKind.Settings : PackIconKind.UndoVariant;
            }
        }
        public string curPwdBd { get; set; }
        public SnackbarMessageQueue messageQueueBd { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.6));

        private DispatcherTimer TimerLoginSuccess = new DispatcherTimer();
        private static bool bFirstLogin { get; set; } = true;
        private static int iPwdChangeCnt { get; set; } = 0;

        #endregion

        #region 委托

        private void GRSocketHandler_ConnState(ApiRes state)
        {
            switch (state)
            {
                case ApiRes.OK:
                    messageQueueBd.Enqueue("已成功连接到服务器");
                    UpdateLinkState(1);
                    break;
                case ApiRes.FAILED:
                    break;
                default:
                    break;
            }
        }

        private void GRSocketHandler_adminLogin(ApiRes state)
        {
            GRSocketHandler.adminLogin -= GRSocketHandler_adminLogin;
            switch (state)
            {
                case ApiRes.OK:
                    ;
                    AdminLoginSuccess();
                    break;
                case ApiRes.FAILED:
                    messageQueueBd.Enqueue("登录失败，请确认用户名或密码正确");
                    break;
                default:
                    break;
            }
        }

        private void TimerLoginSuccess_Tick(object sender, System.EventArgs e)
        {
            messageQueueBd = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.6));
            TimerLoginSuccess.Stop();
            ///注册服务器接口返回处理函数
            GRSocketHandler.ConnState -= GRSocketHandler_ConnState;
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                if (cfgBd.Name == "admin")
                {
                    var wndAdminMainViewModel = new WndAdminMainViewModel(_windowManager);
                    this._windowManager.ShowWindow(wndAdminMainViewModel);
                }
                else
                {
                    var wndUserMainViewModel = new WndUserMainViewModel(_windowManager);
                    this._windowManager.ShowWindow(wndUserMainViewModel);
                }
                this.RequestClose();
            }));
        }
        #endregion

        #region 方法

        public void SettingCmd()
        {
            pageIndexBd = pageIndexBd == 1 ? 0 : 1;
        }
        public void BackCmd()
        {
            pageIndexBd = 0;
        }
        public void QuitCmd()
        {
            this.RequestClose();
        }
        public void pwdChangedCmd()
        {
            iPwdChangeCnt++;
        }
        public void LoginCmd()
        {
            if (iPwdChangeCnt > 1)
                cfgBd.Pwd = Enc.GetMd5Hash(curPwdBd);
            DoLogin(cfgBd.Name, cfgBd.Pwd);
        }
        public void TestLinkCmd()
        {
            TryToLink();
        }
        private void TryToLink()
        {
            GRSocketHandler.ConnState += GRSocketHandler_ConnState;
            GRSocket.Conn(cfgBd.SvrIp);
            UpdateLinkState(0);
        }
        private void CheckAutoLogin()
        {
            if (cfgBd.AutoLogin && bFirstLogin)
                AutoLogin();
        }
        private void AutoLogin()
        {
            messageQueueBd = new SnackbarMessageQueue(TimeSpan.FromSeconds(5));
            messageQueueBd.Enqueue("正在自动登录",
                "取消",
                CancelAutoLogin);
            DoLogin(cfgBd.Name, cfgBd.Pwd);
        }
        private void CancelAutoLogin()
        {
            messageQueueBd = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.6));
            TimerLoginSuccess.Stop();
            messageQueueBd.Enqueue("自动登录已取消");
        }
        void DoLogin(string name, string pwd)
        {
            if (name == "admin")
            {
                GRSocketHandler.adminLogin += GRSocketHandler_adminLogin;
                GRSocketAPI.AdminLogin(pwd);
            }
            else
            {
                GRSocketHandler.login += GRSocketHandler_login;
                GRSocketAPI.Login(name,pwd);
            }
        }

        private void GRSocketHandler_login(ApiRes state, User user)
        {
            GRSocketHandler.login -= GRSocketHandler_login;
            switch (state)
            {
                case ApiRes.OK:
                    ;
                    AdminLoginSuccess();
                    break;
                case ApiRes.FAILED:
                    messageQueueBd.Enqueue("登录失败，请确认用户名或密码正确");
                    break;
                default:
                    break;
            }
            C_RT.user = user;
        }

        private void AdminLoginSuccess()
        {
            Cfg.Set(cfgBd);

            messageQueueBd.Enqueue("登录成功");
            bFirstLogin = false;
            TimerLoginSuccess.Interval = new TimeSpan(0, 0, 0, 3);

            TimerLoginSuccess.Tick += TimerLoginSuccess_Tick;
            TimerLoginSuccess.Start();
        }
        private void UpdateLinkState(int state)
        {
            switch (state)
            {
                case 0:
                    linkStateTextBd = "已断开";
                    linkStateColorBd = Brushes.Red;
                    break;
                case 1:
                    linkStateTextBd = "已连接";
                    linkStateColorBd = Brushes.Green;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
