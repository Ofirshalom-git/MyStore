using OpenQA.Selenium;

namespace Infrastructure
{
    public class HomePage : BasePage
    {
        public ColumnsContainer Columns => new ColumnsContainer(driver, driver.FindElement(By.CssSelector(".columns-container")));
        public HomePage(IWebDriver driver) : base(driver)
        {

        }
    }
}
