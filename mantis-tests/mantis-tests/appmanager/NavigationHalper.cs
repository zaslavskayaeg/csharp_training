using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{

    public class NavigationHalper : HelperBase
    {
        public NavigationHalper(ApplicationManager manager) : base(manager) { }

        public void OpenManagmentMenu ()
        {
            driver.FindElements(By.CssSelector(".menu-text"))[6].Click();
        }

        public void GoToProgectTab()
        {
            driver.FindElements(By.CssSelector(".nav-tabs>li>a"))[2].Click();
        }

    }
}
