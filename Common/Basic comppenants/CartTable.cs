using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class CartTable : ComppenantBase
    {
        public List<IWebElement> Garbage { get; set; }
        public List<IWebElement> Price { get; set; }
        public List<IWebElement> NumOfItems { get; set; }
        private IWebElement Quantity { get; set; }


        public CartTable(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
            try
            {
                Garbage = ParentElement.FindElements(By.CssSelector(".icon-trash")).ToList();
                Price = ParentElement.FindElements(By.CssSelector(".cart_total .price")).ToList();
                NumOfItems = ParentElement.FindElements(By.CssSelector(".cart_quantity.text-center")).ToList();
                Quantity = ParentElement.FindElement(By.CssSelector("#summary_products_quantity"));
            }

            catch
            {
                Quantity = ParentElement.FindElement(By.CssSelector(".alert.alert-warning"));
            }
        }

        public int GetQuantity()
        {
            if(Quantity.Text == "Your shopping cart is empty.")
            {
                return 0;
            }

            var cleanNumOfProducts = new List<char>();
            var numOfProductsString = Quantity.ToString().ToCharArray();
            for(var i = 0; i < numOfProductsString.Length; i++)
            {
                if(numOfProductsString[i].ToString() == " ")
                {
                    break;
                }

                cleanNumOfProducts.Add(numOfProductsString[i]);
            }

            var numOfProducts = int.Parse(cleanNumOfProducts.ToArray().ToString());

            return numOfProducts;
        }
    }
}
