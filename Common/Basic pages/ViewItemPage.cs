using OpenQA.Selenium;

namespace Infrastructure
{
    public class ViewItemPage : BasePage
    {
        public ViewItemRow ViewItemRow => new ViewItemRow(driver, driver.FindElement(By.CssSelector("#product #page")));
        
        public ViewItemPage(IWebDriver driver) : base(driver)
        {

        }
    }
}
