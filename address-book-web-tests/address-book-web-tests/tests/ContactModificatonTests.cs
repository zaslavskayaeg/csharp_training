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
        [SetUp]
        public void SetupAppGroupRemovalTest()
        {
            app.Contact.CheckContactExist();
        }

        [Test]
        public void ContactModificatonTest()
        {
            ContactData contact = new ContactData("Пётр", "Петров");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(contact, 0);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts[0] = contact;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
