using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public class PageSettingViewModel : Screen
    {
        public PageSettingViewModel(WndUserMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            edtTelBd = userBd.tel;
            edtEmailBd = userBd.email;
        }
        private WndUserMainViewModel wndMainVM { get; set; }

        public int pageIndexBd { get; set; } = 0;
        public User userBd { get; set; } = C_RT.user;

        public string edtTelBd { get; set; }
        public string edtEmailBd { get; set; }

        public string oldPwd { get; set; }
        public string newPwd { get; set; }
        public string newPwd2 { get; set; }

        public void SelectPageCmd(string cmdPara)
        {
            wndMainVM.SelectPage((E_Page)Enum.Parse(typeof(E_Page), cmdPara, true));
        }

        public void btnJumpToEdtUserInfoCmd()
        {
            SelectPageCmd("Setting_EdtUserInfo");
            edtTelBd = userBd.tel;
            edtEmailBd = userBd.email;
        }

        public void btnEdtUserCmd()
        {
            if (userBd.tel == edtTelBd && userBd.email == edtEmailBd)
            {
                SelectPageCmd("Setting_UserInfo");
                return;
            }

            GRSocketHandler.edtUser += GRSocketHandler_edtUser; ;
            userBd.tel = edtTelBd;
            userBd.email = edtEmailBd;
            GRSocketAPI.EdtUser(userBd);
        }

        public void btnResetPwdCmd()
        {
            //GRSocketHandler.res += GRSocketHandler_resetPwd;

            if (oldPwd == null || oldPwd == "")
            {
                wndMainVM.messageQueueBd.Enqueue("旧密码为空");
                return;
            }


            if (newPwd == null || newPwd == "")
            {
                wndMainVM.messageQueueBd.Enqueue("新密码为空");
                return;
            }

            if (newPwd2 == null || newPwd2 == "" || newPwd != newPwd2)
            {
                wndMainVM.messageQueueBd.Enqueue("新密码不一致");
                return;
            }

            //GRSocketAPI.ResetPwd(C_Md5.GetHash(oldPwd), C_Md5.GetHash(newPwd));
        }

        private void GRSocketHandler_edtUser(ApiRes state, User user)
        {
            GRSocketHandler.edtUser -= GRSocketHandler_edtUser;
            switch (state)
            {
                case ApiRes.OK:
                    C_RT.user = user;
                    wndMainVM.messageQueueBd.Enqueue("修改用户信息成功");
                    SelectPageCmd("Setting_UserInfo");
                    break;
                case ApiRes.FAILED:
                    wndMainVM.messageQueueBd.Enqueue("修改用户信息失败");
                    break;
                default:
                    break;
            }
            userBd = C_RT.user;
        }
    }
}
