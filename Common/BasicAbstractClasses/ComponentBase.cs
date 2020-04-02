using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class ComponentBase : DriverUser
    {
        protected IWebElement ParentElement { get; private set; }

        public ComponentBase(IWebDriver driver, IWebElement parentElement) : base(driver)
        {
            ParentElement = parentElement;
        }
    }
}
