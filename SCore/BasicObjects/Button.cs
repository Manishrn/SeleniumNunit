using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SCommon.Helpers;
using SCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BasicObjects
{
    public class Button:IClick, IGetText,IVisible
    {
        private readonly By Locator;
        public readonly String Name;

        public Button(By locator, string name)
        {
            this.Locator = locator;
            this.Name = name;
        }

        public string Text => throw new NotImplementedException();

        public bool IsDisplayed => throw new NotImplementedException();

        public bool IsNotDisplayed => throw new NotImplementedException();

        public event EventHandler OnClick;
        public event EventHandler Clicked;

        public void Click(string name)
        {            
             DriverActions.Click(Locator, name);
        }
        public void Click()
        {
            throw new NotImplementedException();
        }

        
    }
}
