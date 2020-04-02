using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Extensions
{
    public static class WaitExtensions
    {
        public static IWebElement FindElement(this ISearchContext iSearchContext, By by)
        {
            var wait = new DefaultWait<ISearchContext>(iSearchContext);
            wait.Timeout = TimeSpan.FromSeconds(20);
            return wait.Until(searchContext =>
            {
                var element = searchContext.FindElement(by);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                if (!element.Enabled || !element.Displayed)
                    return null;
                return element;
            }
                );
        }
    }
}
