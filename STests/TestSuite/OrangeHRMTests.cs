using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STests.TestSuite
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class OrangeHRMTests:Base
    {
        [Test]

        public void OrangeHRMLogin()
        {
            OrangeHRM.Login.LaunchAndLogin("Admin");
        }

        [Test]
        public void OrangeHRMLogin2()
        {
            OrangeHRM.Login.LaunchAndLogin("AdminA");
            Assert.Fail();
        }

        [Test]
        public void OrangeHRMLogin3()
        {
            OrangeHRM.Login.LaunchAndLogin("AdminA2");
        }
    }
}
