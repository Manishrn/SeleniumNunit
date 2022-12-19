using SCommon.Wrappers;
using SCore.Pages;
using System;


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
