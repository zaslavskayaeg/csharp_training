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
            ContactData newData = new ContactData("Пётр", "Петров");

            List<ContactData> oldContacts = ContactData.GetAll();
            foreach (ContactData contact in oldContacts)
            { System.Console.Out.WriteLine("old "+contact.Firstname+" "+ contact.Lastname); }
            ContactData toBeModified = oldContacts[0];

            app.Contact.Modify(newData, toBeModified);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            foreach (ContactData contact in newContacts)
            { System.Console.Out.WriteLine("new " + contact.Firstname + " " + contact.Lastname); }

            oldContacts[0] = newData;
            foreach (ContactData contact in oldContacts)
            { System.Console.Out.WriteLine("oldmodified " + contact.Firstname + " " + contact.Lastname); }

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
