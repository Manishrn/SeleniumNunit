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
    public class Textbox:IText, IClick,IGetText,ISetText
    {
        private readonly By Locator;
        public Textbox(By locator)
        {
            this.Locator = locator;
        }

        public string Text => throw new NotImplementedException();

        public event EventHandler OnClick;
        public event EventHandler Clicked;
        public event EventHandler TextChanged;
        public event EventHandler OnSetText;

        public void AddText(string text)
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public void RemoveText()
        {
            throw new NotImplementedException();
        }

        public void SetText(string text)
        {
            OnSetText?.Invoke(this, EventArgs.Empty);
            DriverActions.SetText(Locator,text);
        }
    }
}
