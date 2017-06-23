using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreateonTests : TestBase
    {
        [Test]
        public void ContactCreateonTest()
        {
            GotoHomePage();
            Login(new AccountData("admin","secret"));
            InitContactCreation();
            ContactData contact = new ContactData("Иван", "Иванов");
            FillContactForm(contact);
            SubmitContactCreation();
            ReternToHomePage();
            Logout();
        }
    }
}
