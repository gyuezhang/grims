using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public class WndAdminMainViewModel : Screen
    {
        private IWindowManager _windowManager;

        public WndAdminMainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }
    }
}
