using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCommon.Wrappers
{
    public class ReportHandler
    {
        public static ConcurrentDictionary<Thread, ExtentTest> testLoggers;
        public static ExtentReports extent { get; set; }

        public ReportHandler()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"reports","TestResults.html"));
            htmlReporter.Config.DocumentTitle = "Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AttachReporter(htmlReporter);
        }

        static ReportHandler()
        {             
            testLoggers= new ConcurrentDictionary<Thread,ExtentTest>();
            extent = new ExtentReports();
        }

        public static ExtentTest CreateTest(string testName)
        {
            ExtentTest  testLogger = extent.CreateTest(testName);
            if (!testLoggers.TryAdd(Thread.CurrentThread, testLogger))
            {
                Console.WriteLine($"The logger is the thread {Thread.CurrentThread} not added !");
            }
            ReportHandler.Log(Status.Info, $" exexution of test {testName} started");
            return testLogger;
        }

        public static void Log(Status status, string details)
        {
            ExtentTest selectedLogger;

            if (testLoggers.TryGetValue(Thread.CurrentThread, out selectedLogger))
            {
                selectedLogger.Log(status, details);
            }
        
        }


        public static void Log(Status status, MediaEntityModelProvider details)
        {
            ExtentTest selectedLogger;

            if (testLoggers.TryGetValue(Thread.CurrentThread, out selectedLogger))
            {
                selectedLogger.Log(status, details);
            }

        }

        public static void Capture(string screenShotName)
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    string screenShotFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshot", $"{screenShotName}.png");
                    ITakesScreenshot ts = (ITakesScreenshot)Browser.GetDriver();
                    ts.GetScreenshot().SaveAsFile(screenShotFileName, ScreenshotImageFormat.Png);
                    TestContext.AddTestAttachment(screenShotFileName);
                    string screenShot = ts.GetScreenshot().AsBase64EncodedString;
                    MediaEntityModelProvider sc=MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build();
                    if (sc != null)
                    {
                        ReportHandler.Log(Status.Fail,sc);
                    }
                

                }
            }
            catch (Exception)
            {

                ReportHandler.Log(Status.Fail, "Screeshot capture failed");
            }
        }

        public void Close()
        { 
            extent.Flush();
        }
    }
}
