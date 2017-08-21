using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProgectRemovalTests : AuthTestBase
    {
        [SetUp]
        public void SetupAppProgectRemovalTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Progect1",
            };

            app.Progects.CreateIfNoProjectsPresent(account, project);
        }

        [Test]
        public void ProgectRemovalTest()
        {
            //List <ProjectData> oldProgects = app.Progects.GetProgectList();
            List<ProjectData> oldProgects = app.Progects.GetProjectList(account);

            ProjectData toBeRemoved = oldProgects[0];

            app.Progects.Remove(toBeRemoved);

            Assert.AreEqual(oldProgects.Count - 1, app.Progects.GetProjectCount());

            //List<ProjectData> newProgects = app.Progects.GetProgectList();
            List<ProjectData> newProgects = app.Progects.GetProjectList(account);

            oldProgects.RemoveAt(0);

            Assert.AreEqual(oldProgects, newProgects);
        }
    }
}
