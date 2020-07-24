using Stylet;

namespace GRCLNT
{
    public class PageAdminGroupMngViewModel : Screen
    {
        public PageAdminGroupMngViewModel(WndAdminMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndAdminMainViewModel wndMainVM { get; set; }

        public void AddDeptCmd()
        {
            GRSocketHandler.addDept += GRSocketHandler_addDept;
            Dept dept = new Dept();
            dept.name = "erha3";
            dept.avator = -1;
            dept.remark = "d";
            GRSocketAPI.AddDept(dept);
        }

        private void GRSocketHandler_addDept(ApiRes state)
        {
            GRSocketHandler.addDept -= GRSocketHandler_addDept;
            switch(state)
            {
                case ApiRes.OK:
                    break;
                case ApiRes.FAILED:
                    break;
                default:
                    break;
            }
        }

        public void DelDeptCmd()
        {
            GRSocketHandler.delDept += GRSocketHandler_delDept;
            GRSocketAPI.DelDept(3);
        }

        private void GRSocketHandler_delDept(ApiRes state)
        {
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
            GRSocketHandler.edtDept -= GRSocketHandler_edtDept;
        }

        public void AddUserCmd()
        {

        }

        public void GetDepts()
        {
            GRSocketHandler.getDepts += GRSocketHandler_getDepts;
            GRSocketAPI.GetDepts();
        }

        private void GRSocketHandler_getDepts(ApiRes state, System.Collections.Generic.List<Dept> depts)
        {
            GRSocketHandler.getDepts -= GRSocketHandler_getDepts;
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
    }
}
