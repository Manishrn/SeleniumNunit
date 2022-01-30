using OpenQA.Selenium;
using SCommon.Wrappers;
using SCore.BasicObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCore.Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
            UserName = new Textbox(By.XPath("//*[@id='txtUsername']"));
            PassWord = new Textbox(By.XPath("//*[@id='txtPassword']"));
            LoginButton = new Button(By.XPath("//*[@id='btnLogin']"));
        }

        public Textbox UserName { get; }
        public Textbox PassWord { get; }
        public Button LoginButton { get; }

        public void LaunchAndLogin(string userName)
        {
            Browser.CreateDriver();
            Browser.Navigate("https://opensource-demo.orangehrmlive.com/");
            UserName.SetText(userName);
            PassWord.SetText("admin123");
            LoginButton.Click();
            Thread.Sleep(5000);
        }
    }
}
