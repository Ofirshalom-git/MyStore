using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Infrastructure
{
    public class Item : ComponentBase
    {
        public IWebElement Name => parentElement.FindElement(By.CssSelector(".right-block a.product-name"));
        public Button AddToCartButton => new Button(driver, parentElement.FindElement(By.CssSelector(".product-container .button-container .ajax_add_to_cart_button")));
        public Button ViewButton => new Button(driver, parentElement.FindElement(By.CssSelector(".lnk_view.btn.btn-default")));
        public Button QuickViewButton => new Button(driver, parentElement.FindElement(By.CssSelector(".quick-view")));
        public IWebElement Price => parentElement.FindElement(By.CssSelector(".right-block .price.product-price"));
        public ColorRow OptionalColors => new ColorRow(driver, parentElement.FindElement(By.CssSelector(".color_to_pick_list.clearfix")));
        public BuyingItemWindow BuyingItemWindow => new BuyingItemWindow(driver, parentElement.FindElement(By.CssSelector("#layer_cart .clearfix")));

        public Item(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }

        public QuickViewWindow ClickQuickView() =>
            QuickViewButton.Click<QuickViewWindow>();

        public CatalogPage ClickByItemIndex() =>
            AddToCartButton.Click<CatalogPage>();

        public BuyingItemWindow ClickAddToCart() =>
            AddToCartButton.Click<BuyingItemWindow>();

        public double GetPrice =>            
            double.Parse(Price.Text.Remove(0, 1));
        
        public CatalogPage HoverOnItemByIndex()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.CssSelector("li .product-container")));

            return new CatalogPage(driver);
        }
    }
}
