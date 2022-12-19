using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCommon.Wrappers
{
    public class Browser
    {
        static ConcurrentDictionary<Thread, IWebDriver> drivers = new ConcurrentDictionary<Thread, IWebDriver>();


        public static IWebDriver CreateDriver()
        {
            IWebDriver driver;
            driver = new ChromeDriver(@"D:\Manish\Study\ChromeExe");
            driver.Manage().Window.Maximize();

            if (!drivers.TryAdd(Thread.CurrentThread, driver))
            {
                Console.WriteLine("Driver is not added!!!");
            }
            return driver;

        }

        public static void Quit()
        {
            GetDriver().Quit();
            if (!drivers.TryRemove(Thread.CurrentThread, out _))
            {
                Console.WriteLine("Could not remove driver!!!");
            }
        }

        public static IWebDriver GetDriver()
        {

            IWebDriver selectedDriver;
            if (drivers.TryGetValue(Thread.CurrentThread, out selectedDriver))
            {
                return selectedDriver;
            }
            else
            {
                throw new Exception("Driver did not found!!!");
            }

        }

        public static void Navigate(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }
    }
}
