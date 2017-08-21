using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProgectCreateonTests : AuthTestBase
    {
        [Test]
        public void ProgectCreateonTest()
        {
            ProjectData progect = new ProjectData()
            {
                Name = "Progect31",
                Description = ""
            };

            //app.Progects.DeleteIfSuchProjectExist(progect);
            app.Progects.DeleteIfSuchProjectExist(account, progect);

            //List<ProjectData> oldProgects = app.Progects.GetProgectList();
            List<ProjectData> oldProgects = app.Progects.GetProjectList(account);

            app.Progects.Create(progect);

            Assert.AreEqual(oldProgects.Count + 1, app.Progects.GetProjectCount());

            //List<ProjectData> newProgects = app.Progects.GetProgectList();
            List<ProjectData> newProgects = app.Progects.GetProjectList(account);

            oldProgects.Add(progect);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);

        }
    }
}
