using OpenQA.Selenium;
using System;

namespace Infrastructure
{
    public class Button : ComponentBase
    { 
        public Button(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }

        public T Click<T>()
        {
            ParentElement.Click();
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }

        public bool IsEnabled() =>
            ParentElement.Enabled;
    }
}
