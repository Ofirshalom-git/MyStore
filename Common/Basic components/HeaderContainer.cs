using OpenQA.Selenium;

namespace Infrastructure
{
    public class HeaderContainer : ComponentBase
    {
        public Button CartButton => new Button(Driver, Driver.FindElement(By.CssSelector(".shopping_cart a")));
        public Button MyStoreButton => new Button(Driver, Driver.FindElement(By.CssSelector("#header_logo a")));
        public CatalogCategories CatalogCategories => new CatalogCategories(Driver, Driver.FindElement(By.CssSelector("#block_top_menu ul")));

        public HeaderContainer(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }
    }
}
