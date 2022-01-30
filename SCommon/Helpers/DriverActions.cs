using OpenQA.Selenium;
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
        public static void Click(By by,int timeout=20)
        {
            try
            {
                 var element = Browser.GetDriver().FindElement(by);
                if (element.Displayed) element.Click();
                else return;


            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void SetText(By by, string text)
        {

            try
            {
                var element = Browser.GetDriver().FindElement(by);
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
