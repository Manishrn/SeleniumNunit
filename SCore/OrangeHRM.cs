using OpenQA.Selenium;
using SCommon.Wrappers;
using SCore.BasicObjects;
using SCore.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore
{
    public class OrangeHRM:IDisposable
    {
        public OrangeHRM()
        {
            Login = new LoginPage();
        }

        public LoginPage Login { get; }

        public void Dispose()
        {
            try
            {
                Browser.Quit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
