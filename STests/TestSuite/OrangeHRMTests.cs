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

        [TestCase ("Admin")]
       // [TestCase ("Admin1")]
       // [TestCase ("Admin2")]
        public void OrangeHRMLogin(string username)
        {
            OrangeHRM.Login.LaunchAndLogin(username);
        }

        [Test]
        public void OrangeHRMLogin2Fail()
        {
            OrangeHRM.Login.LaunchAndLogin("AdminA");
            Assert.Pass();
        }

        [Test]
        public void OrangeHRMLogin3Fail()
        {
            OrangeHRM.Login.LaunchAndLogin("AdminA2");
            Assert.Fail();
        }
    }
}
