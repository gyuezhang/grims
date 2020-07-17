using Stylet;

namespace GRCLNT
{
    public class PageAdminDashboardViewModel : Screen
    {
        public PageAdminDashboardViewModel(WndAdminMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndAdminMainViewModel wndMainVM { get; set; }

    }
}
