﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}