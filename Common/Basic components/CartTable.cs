using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Extensions; 

namespace Infrastructure
{
    public class CartTable : ComponentBase
    {
        public List<IWebElement> Garbage { get; set; }
        public List<IWebElement> Price { get; set; }
        public List<IWebElement> NumOfItems { get; set; }
        private IWebElement Quantity { get; set; }


        public CartTable(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
            if(ParentElement.FindElement(By.CssSelector("#summary_products_quantity")).Enabled)
            {
                Garbage = parentElement.FindElements(By.CssSelector(".icon-trash")).ToList();
                Price = parentElement.FindElements(By.CssSelector(".cart_total .price")).ToList();
                NumOfItems = parentElement.FindElements(By.CssSelector(".cart_quantity.text-center")).ToList();
                Quantity = ParentElement.FindElement(By.CssSelector("#summary_products_quantity"));
            }

            else
            {
                Quantity = ParentElement.FindElement(By.CssSelector(".alert.alert-warning"));
            }
        }

        public int GetQuantity() =>
            QuantityExtensions.GetQuantity(Quantity);

    }
}
