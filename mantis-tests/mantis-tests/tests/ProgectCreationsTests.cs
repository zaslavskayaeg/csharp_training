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
                Name = "Progect1",
                Description = ""
            };

            app.Progects.DeleteIfSuchProgectExist(progect);

            List<ProjectData> oldProgects = app.Progects.GetProgectList();

            app.Progects.Create(progect);

            Assert.AreEqual(oldProgects.Count + 1, app.Progects.GetProgectCount());

            List<ProjectData> newProgects = app.Progects.GetProgectList();

            oldProgects.Add(progect);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);

        }
    }
}
