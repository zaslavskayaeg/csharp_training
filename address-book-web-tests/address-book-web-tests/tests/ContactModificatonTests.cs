using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificatonTests : AuthTestBase
    {
        [Test]
        public void ContactModificatonTest()
        {
            ContactData contact = new ContactData("Пётр", "Петров");

            app.Contact.CheckContactExist()
                .Modify(contact, 1);
        }
    }
}
