﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        internal AccountData account = new AccountData()
        {
            Name = "administrator",
            Password = "root"
        };

        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(account);
        }
    }
}
