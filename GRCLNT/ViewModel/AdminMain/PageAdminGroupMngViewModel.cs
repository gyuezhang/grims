using Stylet;
using System.Collections.Generic;
using System.Windows;

namespace GRCLNT
{
    public class PageAdminGroupMngViewModel : Screen
    {
        public PageAdminGroupMngViewModel(WndAdminMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            groupTvBd.Add(new GroupTvNode());
            GetDepts();
            GetUsers();
        }
        private WndAdminMainViewModel wndMainVM { get; set; }

        public Dept cDeptBd { get; set; } = new Dept();
        public string cDeptDefaultAvatorBd { get; set; } = "-1";

        public User cUserBd { get; set; } = new User();
        public string cUserDefaultAvatorBd { get; set; } = "-1";

        public void AddDeptCmd()
        {
            GRSocketHandler.addDept += GRSocketHandler_addDept;
            cDeptBd.avator = -1;
            GRSocketAPI.AddDept(cDeptBd);
        }
        public int addPageBd { get; set; } = 0;
        private void GRSocketHandler_addDept(ApiRes state)
        {
            GRSocketHandler.addDept -= GRSocketHandler_addDept;
            GetDepts();
            switch (state)
            {
                case ApiRes.OK:
                    break;
                case ApiRes.FAILED:
                    break;
                default:
                    break;
            }
        }

        public void SelectPageCmd(string s)
        {
            DeptAuthBtnVisi = Visibility.Collapsed;
            UserAuthBtnVisi = Visibility.Collapsed;
            UserAuthCtrlVisi = Visibility.Collapsed;
            DeptAuthCtrlVisi = Visibility.Collapsed;
            addOrEdt = true;
            int i = int.Parse(s);
            addPageBd = i;
            if (addPageBd == 1)
            {
                cDeptBd = new Dept();
                addEdtDeptBtnTextBd = "添加部门";
            }
            else if(addPageBd == 2)
            {
                cUserBd = new User();
                addEdtUserBtnTextBd = "添加用户";
            }
        }

        public void DelDept(int id)
        {
            GRSocketHandler.delDept += GRSocketHandler_delDept;
            GRSocketAPI.DelDept(id);
        }

        public void DelUser(int id)
        {
            GRSocketHandler.delUser += GRSocketHandler_delUser;
            GRSocketAPI.DelUser(id);
        }

        private void GRSocketHandler_delUser(ApiRes state)
        {
            GRSocketHandler.delUser -= GRSocketHandler_delUser;
            GetUsers();
        }

        private void GRSocketHandler_delDept(ApiRes state)
        {
            GetDepts();
            GRSocketHandler.delDept -= GRSocketHandler_delDept;
            switch (state)
            {
                case ApiRes.OK:
                    break;
                case ApiRes.FAILED:
                    break;
                default:
                    break;
            }
        }

        public void EdtDeptCmd()
        {
            GRSocketHandler.edtDept += GRSocketHandler_edtDept;
            GRSocketAPI.EdtDept(cDeptBd);
        }

        private void GRSocketHandler_edtDept(ApiRes state)
        {
            GetDepts();
            GRSocketHandler.edtDept -= GRSocketHandler_edtDept;
        }

        public void AddUserCmd()
        {
            GRSocketHandler.addUser += GRSocketHandler_addUser;
            cUserBd.avator = -1;
            cUserBd.deptid = curSelDeptBd.id;
            cUserBd.sex = false;
            cUserBd.birthday = System.DateTime.Now;
            GRSocketAPI.AddUser(cUserBd);
        }

        public void EdtUserCmd()
        {
            GRSocketHandler.edtUser += GRSocketHandler_edtUser;
            GRSocketAPI.EdtUser(cUserBd);
        }

        private void GRSocketHandler_edtUser(ApiRes state)
        {
            GRSocketHandler.edtUser -= GRSocketHandler_edtUser;
            GetUsers();
        }

        private void GRSocketHandler_addUser(ApiRes state)
        {
            GRSocketHandler.addUser -= GRSocketHandler_addUser;
            GetUsers();
        }

        public void GetDepts()
        {
            GRSocketHandler.getDepts += GRSocketHandler_getDepts;
            GRSocketAPI.GetDepts();
        }

        public void GetUsers()
        {
            GRSocketHandler.getUsers += GRSocketHandler_getUsers;
            GRSocketAPI.GetUsers();
        }

        private void GRSocketHandler_getUsers(ApiRes state, List<User> users)
        {
            GRSocketHandler.getUsers -= GRSocketHandler_getUsers;
            switch (state)
            {
                case ApiRes.OK:
                    curUsersBd = users;
                    groupTvBd[0].Update(curDeptsBd, curUsersBd);
                    break;
                case ApiRes.FAILED:
                    break;
                default:
                    break;
            }
        }

        public List<User> curUsersBd { get; set; } = new List<User>();
        public User curSelUserBd { get; set; } = new User();

        public List<Dept> curDeptsBd { get; set; } = new List<Dept>();
        public Dept curSelDeptBd { get; set; } = new Dept();


        private void GRSocketHandler_getDepts(ApiRes state, System.Collections.Generic.List<Dept> depts)
        {
            GRSocketHandler.getDepts -= GRSocketHandler_getDepts;
            switch (state)
            {
                case ApiRes.OK:
                    curDeptsBd = depts;
                    groupTvBd[0].Update(curDeptsBd, curUsersBd);
                    break;
                case ApiRes.FAILED:
                    break;
                default:
                    break;
            }
        }

        public List<GroupTvNode> groupTvBd { get; set; } = new List<GroupTvNode>();

        private GroupTvNode curSelGroup { get; set; } = new GroupTvNode();

        public void ClickItemCommand(GroupTvNode node)
        {
            curSelGroup = node;
        }

        public bool CanEditGroup => curSelGroup.Id != 0 && curSelGroup.Type != GroupType.Company;
        public void EditGroup()
        {
            DeptAuthBtnVisi = Visibility.Visible;
            UserAuthBtnVisi = Visibility.Visible;
               addOrEdt = false;
            if (curSelGroup.Type == GroupType.Dept)
            {
                addPageBd = 1;
                cDeptBd = curDeptsBd.Find(e => e.id == curSelGroup.Id);
                addEdtDeptBtnTextBd = "保存部门";
            }
            else if (curSelGroup.Type == GroupType.User)
            {
                addPageBd = 2;
                cUserBd = curUsersBd.Find(e => e.id == curSelGroup.Id);
                addEdtUserBtnTextBd = "保存用户";
            }
        }

        public bool CanDelGroup => curSelGroup.Id != 0 && curSelGroup.Type != GroupType.Company;
        public void DelGroup()
        {

            if (curSelGroup.Type == GroupType.Dept)
            {
                DelDept(curSelGroup.Id);
            }
            else if (curSelGroup.Type == GroupType.User)
            {
                DelUser(curSelGroup.Id);
            }
        }

        public string addEdtUserBtnTextBd { get; set; }
        public string addEdtDeptBtnTextBd { get; set; }

        private bool addOrEdt { get; set; }

        public void AddEdtDeptCmd()
        {
            if (addOrEdt)
            {
                AddDeptCmd();
            }
            else
            {
                EdtDeptCmd();
            }
        }

        public void AddEdtUserCmd()
        {
            if (addOrEdt)
            {
                AddUserCmd();
            }
            else
            {
                EdtUserCmd();
            }
        }

        public Visibility UserAuthCtrlVisi { get; set; } = Visibility.Collapsed;
        public Visibility DeptAuthCtrlVisi { get; set; } = Visibility.Collapsed;

        public Visibility UserAuthBtnVisi { get; set; } = Visibility.Collapsed;
        public Visibility DeptAuthBtnVisi { get; set; } = Visibility.Collapsed;

        public bool CanEdtUserAuthCmd => UserAuthCtrlVisi == Visibility.Collapsed;
        public void EdtUserAuthCmd()
        {
            UserAuthCtrlVisi = Visibility.Visible;
        }

        public bool CanEdtDeptAuthCmd => DeptAuthCtrlVisi == Visibility.Collapsed;
        public void EdtDeptAuthCmd()
        {
            DeptAuthCtrlVisi = Visibility.Visible;
        }
    }
}
