using OpenQA.Selenium;
using SCommon.Helpers;
using SCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BasicObjects
{
    public class Button: IClick, IGetText,IVisible
    {
        private readonly By Locator;
        public Button(By locator)
        {
            this.Locator = locator;
        }

        public string Text => throw new NotImplementedException();

        public bool IsDisplayed => throw new NotImplementedException();

        public bool IsNotDisplayed => throw new NotImplementedException();

        public event EventHandler OnClick;
        public event EventHandler Clicked;

        public void Click()
        {
            DriverActions.Click(Locator);
        }
    }
}
