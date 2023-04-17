using NUnit.Framework;
using SCommon.Wrappers;
using SCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: LevelOfParallelism(10)]
namespace STests
{
    
    public class Base
    {
        internal OrangeHRM OrangeHRM;

        [SetUp]
        public void StartTest()
        {
            Console.WriteLine("Start");
            ReportHandler.CreateTest(TestContext.CurrentContext.Test.Name);
            OrangeHRM = new OrangeHRM();
           
        }

        [TearDown]
        public void EndTest()
        {
            ReportHandler.Capture(TestContext.CurrentContext.Test.Name);
            //if (TestContext.CurrentContext.Result.Equals(false)) 
            //{
            //    Assert.Fail();
            //}
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, $"Test failed {TestContext.CurrentContext.Test.Name} ");
            }
            OrangeHRM?.Dispose();
            OrangeHRM=null;
        }
    }
}
