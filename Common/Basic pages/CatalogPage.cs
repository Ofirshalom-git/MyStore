using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class CatalogPage : BasePage
    {
        public Filters Filters { get; set; }
        public List<Item> Items => Driver.FindElements(By.CssSelector(".product_list.grid.row li .product-container")).Select(element => new Item(Driver, element)).ToList();
        public List<IWebElement> ViewedItemsName => Driver.FindElements(By.CssSelector("#viewed-products_block_left div ul li a.product-name")).ToList();
        public QuickViewWindow QuickViewWindow => new QuickViewWindow(Driver, Driver.FindElement(By.CssSelector(".fancybox-inner")));
        public BuyingItemWindow BuyingItemWindow => new BuyingItemWindow(Driver, Driver.FindElement(By.CssSelector("#layer_cart .clearfix")));
        public CatalogPage(IWebDriver driver) : base(driver)
        {

        }
    }
}
