using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TextBox : ComponentBase
    {
        public TextBox(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }

        public void Fill(string text) =>        
            parentElement.SendKeys(text);                    
    }
}
