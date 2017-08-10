﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            WINTITLE = ApplicationManager.WINTITLE;
            this.aux = manager.Aux;
        }
    }
}