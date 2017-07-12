using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [SetUp]
        public void SetupAppGroupRemovalTest()
        {
            app.Contact.CheckContactExist();
        }

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();

            ContactData toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                //Console.Out.Write("ИД текущего контакта <"+contact.Id+"> <> ИД удалённого контакта <"+toBeRemoved.Id+">"+'\n');
                Assert.AreNotEqual(toBeRemoved.Id, contact.Id);
            }
        }
    }
}
