using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STests
{
    [SetUpFixture]
    public class TestsSetup
    {

        [OneTimeSetUp]

        public void Start()
            {
            Console.WriteLine("Automation execution started!!!");
            }

        [OneTimeTearDown]

        public void End()
        {
            Console.WriteLine("Automation execution Ended!!!");
        }
    }
}
