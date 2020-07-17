using Stylet;

namespace GRCLNT
{
    public class PageAdminAnmMngViewModel : Screen
    {
        public PageAdminAnmMngViewModel(WndAdminMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndAdminMainViewModel wndMainVM { get; set; }

    }
}
