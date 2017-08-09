using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [SetUp]
        public void SetupAppGroupRemovalTest()
        {
            app.Groups.CheckGroupExist();
        }


        [Test]
        public void GroupRemovalTest()
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];

             app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
