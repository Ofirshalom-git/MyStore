using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class BasePage : DriverUser
    {
        public HeaderContainer Header => new HeaderContainer(driver, driver.FindElement(By.CssSelector("#header")));
        protected FooterContainer Footer;

        public BasePage(IWebDriver driver) : base(driver)
        {

        }

        public CatalogPage GoToCatalogPage() =>
            Header.CatalogCategories.ClickOnWomenCategory();        
    }
}
