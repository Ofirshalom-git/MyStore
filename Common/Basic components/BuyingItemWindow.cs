using OpenQA.Selenium;

namespace Infrastructure
{
    public class BuyingItemWindow : ComponentBase
    {
        public Button ContinueShoppingButton => new Button(driver, parentElement.FindElement(By.CssSelector("span.continue.btn.btn")));
        public BuyingItemWindow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }

        public CatalogPage BackToCatalogPage() =>
            ContinueShoppingButton.Click<CatalogPage>();
    }
}
