using Stylet;

namespace GRCLNT
{
    public class PageAdminLogMngViewModel : Screen
    {
        public PageAdminLogMngViewModel(WndAdminMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndAdminMainViewModel wndMainVM { get; set; }

    }
}
