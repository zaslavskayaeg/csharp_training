﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuteFixture
    {
        [SetUp]
        public void InitApplicationManager () 
        {
            ApplicationManager app = ApplicationManager.GetInstance();

            app.Navigator.GotoHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
