using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class DriverUser
    {
        protected IWebDriver Driver { get; private set; }

        public DriverUser(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
