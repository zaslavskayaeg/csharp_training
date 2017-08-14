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
            if (!IsElementPresent(By.XPath("//div[@id='sidebar']/ul/li[@class='active']/a" +
                "/span[contains(text(),'управление')]")))
            {
                driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li/a" +
                    "/span[contains(text(),'управление')]")).Click();
            }

        }

        public void GoToProgectTab()
        {
            OpenManagmentMenu();
            if (!IsElementPresent(By.XPath("//div[@id='main-container']/div[2]/div[2]/div" +
                "/ul/li[@class='active']/a[contains(text(),'Управление проектами')]")))
            {
                driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div" +
                "/ul/li/a[contains(text(),'Управление проектами')]")).Click();
            }

        }

        public void OpenMainPage()
        {
            if(driver.Url != "http://localhost/mantisbt-2.5.1/login_page.php")
            {
                manager.Driver.Url ="http://localhost/mantisbt-2.5.1/login_page.php";
            }
        }
    }
}
