using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreateonTests : AuthTestBase
    {
        [Test]
        public void ContactCreateonTest()
        {
            ContactData contact = new ContactData("Иван", "Иванов");

            app.Contact.Create(contact);
        }

        [Test]
        public void EmptyContactCreateonTest()
        {
            ContactData contact = new ContactData("", "");

            app.Contact.Create(contact);
        }
    }
}
