using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [SetUp]
        public void SetupAppGroupRemovalTest()
        {
            app.Groups.CheckGroupExist();
        }


        [Test]
        public void GroupRemovalTest()
        {

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                //Console.Out.Write("ИД текущего контакта <" + group.Id + "> не равно ИД удалённого контакта <" + toBeRemoved.Id + ">" + '\n');
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
