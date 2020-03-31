using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class DriverUser
    {
        protected IWebDriver driver { get; private set; }

        public DriverUser(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
