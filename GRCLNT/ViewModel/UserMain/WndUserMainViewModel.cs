﻿using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public class WndUserMainViewModel : Screen
    {
        private IWindowManager _windowManager;

        public WndUserMainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }
    }
}
