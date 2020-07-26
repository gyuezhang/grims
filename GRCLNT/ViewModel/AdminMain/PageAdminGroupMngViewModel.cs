using Stylet;
using System.Collections.Generic;

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
            int i = int.Parse(s);
            addPageBd = i;
        }

        public void DelDeptCmd()
        {
            GRSocketHandler.delDept += GRSocketHandler_delDept;
            GRSocketAPI.DelDept(3);
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
            Dept dept = new Dept();
            dept.id = 4;
            dept.name = "jinmao";
            dept.avator = -1;
            GRSocketAPI.EdtDept(dept);
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

        private void GRSocketHandler_addUser(ApiRes state)
        {
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

        public void ClickItemCommand()
        {

        }
    }
}
