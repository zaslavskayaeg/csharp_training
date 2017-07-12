using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreateonTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void BadNameContactCreateonTest()
        {
            ContactData contact = new ContactData("a'a", "bb");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
