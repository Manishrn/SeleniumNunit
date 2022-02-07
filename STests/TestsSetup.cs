﻿using NUnit.Framework;
using SCommon.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STests
{
    [SetUpFixture]
    public class TestsSetup
    {

        static ReportHandler extent;


        [OneTimeSetUp]

        public static void Start()

            {
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshot"));
            ReportHandler.Log(AventStack.ExtentReports.Status.Info, "Test started!!");
            Console.WriteLine("Automation execution started!!!");

            extent = new ReportHandler();
            }

        [OneTimeTearDown]

        public static void End()
        {
            Console.WriteLine("Automation execution Ended!!!");
            extent.Close();
        }
    }
}
