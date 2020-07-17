using Stylet;

namespace GRCLNT
{
    public class PageAdminSettingViewModel : Screen
    {
        public PageAdminSettingViewModel(WndAdminMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndAdminMainViewModel wndMainVM { get; set; }


        private void GRSocketHandler_adminResetPwd(ApiRes state)
        {
            GRSocketHandler.adminResetPwd -= GRSocketHandler_adminResetPwd;
            switch (state)
            {
                case ApiRes.OK:
                    wndMainVM.messageQueueBd.Enqueue("重置密码成功，建议尽快重新登录");
                    break;
                case ApiRes.FAILED:
                    wndMainVM.messageQueueBd.Enqueue("重置密码失败");
                    break;
                default:
                    break;
            }
        }


        #region Bindings        

        public int pageIndexBd { get; set; } = 0;
        public string pwdOldBd { get; set; } = "";
        public string pwdNewBd { get; set; } = "";
        public string pwdNew2Bd { get; set; } = "";

        #endregion Bindings

        #region Actions

        public void changePwdOKCmd()
        {
            if (pwdOldBd == "")
            {
                wndMainVM.messageQueueBd.Enqueue("旧密码不能为空");
                return;
            }

            if (pwdNewBd == "")
            {
                wndMainVM.messageQueueBd.Enqueue("新密码不能为空");
                return;
            }

            if (pwdNewBd != pwdNew2Bd)
            {
                wndMainVM.messageQueueBd.Enqueue("新密码不一致");
                return;
            }

            if (pwdOldBd == pwdNewBd)
            {
                wndMainVM.messageQueueBd.Enqueue("新旧密码一致，未作出更改");
                return;
            }

            GRSocketHandler.adminResetPwd += GRSocketHandler_adminResetPwd;
            GRSocketAPI.AdminResetPwd(Enc.GetMd5Hash(pwdOldBd), Enc.GetMd5Hash(pwdNewBd));
        }

        #endregion Actions
    }
}
