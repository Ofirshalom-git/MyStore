using OpenQA.Selenium;

namespace Infrastructure
{
    public class CartPage : BasePage
    {
        public CartTable CartTable => new CartTable(driver, driver.FindElement(By.CssSelector("#center_column")));

        public CartPage(IWebDriver driver) : base(driver)
        {

        }
    }
}
