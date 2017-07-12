﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
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

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                //Console.Out.Write("ИД текущего контакта <" + group.Id + "> не равно ИД удалённого контакта <" + toBeRemoved.Id + ">" + '\n');
                Assert.AreNotEqual(toBeRemoved.Id, group.Id);
            }
        }
    }
}
