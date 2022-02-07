using NUnit.Framework;
using SCommon.Wrappers;
using SCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: LevelOfParallelism(4)]
namespace STests
{
    
    public class Base
    {
        internal OrangeHRM OrangeHRM;

        [SetUp]
        public void StartTest()
        {
            ReportHandler.CreateTest(TestContext.CurrentContext.Test.Name);
            OrangeHRM = new OrangeHRM();

        }

        [TearDown]
        public void EndTest()
        {
            ReportHandler.Capture(TestContext.CurrentContext.Test.Name);
            OrangeHRM.Dispose();
        }
    }
}
