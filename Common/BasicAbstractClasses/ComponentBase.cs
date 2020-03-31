using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class ComponentBase : DriverUser
    {
        protected IWebElement parentElement { get; private set; }

        public ComponentBase(IWebDriver driver, IWebElement parentElement) : base(driver)
        {
            this.parentElement = parentElement;
        }
    }
}
