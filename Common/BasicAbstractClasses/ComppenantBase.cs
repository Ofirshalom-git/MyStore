using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class ComppenantBase : DriverUser
    {
        protected IWebElement ParentElement { get; private set; }

        public ComppenantBase(IWebDriver driver, IWebElement parentElement) : base(driver)
        {
            ParentElement = parentElement;
        }
    }
}
