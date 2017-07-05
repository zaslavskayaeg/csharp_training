using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactHelper Remove(int i)
        {
            manager.Navigator.GotoHomePage();
            CheckContactExist();
            SelectContact(i);
            RemoveContact();

            return this;
        }

        private void CheckContactExist()
        {
            if (!IsElementPresent(By.XPath(".//*[@id='maintable']/tbody/tr[@name='entry']")))
            {
                ContactData contact = new ContactData("", "");

                Create(contact);
            }
        }

        internal ContactHelper Modify(ContactData contact, int i)
        {
            manager.Navigator.GotoHomePage();
            CheckContactExist();
            InitContactModification(i);
            FillContactForm(contact);
            SubmitСontactModification();
            ReternToHomePage();

            return this;
        }

        private ContactHelper SubmitСontactModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath(".//*[@id='maintable']/tbody/tr[@name='entry']["+ index +"]/td[8]/a/img")).Click();

            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();

            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        internal ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReternToHomePage();

            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper ReternToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

    }
}
