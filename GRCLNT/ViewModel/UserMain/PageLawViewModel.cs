﻿using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public class PageLawViewModel : Screen
    {
        public PageLawViewModel(WndUserMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndUserMainViewModel wndMainVM { get; set; }
        public int pageIndexBd { get; set; } = 0;

    }
}
