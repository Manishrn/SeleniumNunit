using NUnit.Framework;
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
            OrangeHRM = new OrangeHRM();
        }

        [TearDown]
        public void EndTest()
        { 
        OrangeHRM.Dispose();
        }
    }
}
