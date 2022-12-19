using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SCommon.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommon.Helpers
{
    public static class DriverActions
    {
        public static void Click(By by, string name, int timeout=20)
        {
            try
            {
                 var element = Browser.GetDriver().FindElement(by);
                Actions actions = new Actions(Browser.GetDriver());
                WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
                wait.Until(driver=>driver.FindElement(by));
                actions.Click(element).Perform();
                ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"{name} Clicked");
                //if (element.Displayed) element.Click();
               // else return;

            }
            catch (Exception)
            {
                ReportHandler.Log(AventStack.ExtentReports.Status.Info,$"{name} element did not find!");
                throw;
            }
        }


        public static void SetText(By by, string text)
        {

            try
            {
                var element = Browser.GetDriver().FindElement(by);
                ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"Set text to {element.Text}");
                element.Click();
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
