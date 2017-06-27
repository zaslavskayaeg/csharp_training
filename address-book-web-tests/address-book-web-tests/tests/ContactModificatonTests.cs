using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificatonTests : TestBase
    {
        [Test]
        public void ContactModificatonTest()
        {
            ContactData contact = new ContactData("Пётр", "Петров");

            app.Contact.Modify(contact, 1);
        }
    }
}
