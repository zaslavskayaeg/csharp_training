using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ContactCreateonTests : TestBase
    {
      
        [Test]
        public void ContactCreateonTest()
        {
             List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData contact = new ContactData()
            {
                Firstname = "Иван",
                Lastname = "Иванов"
            };

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
