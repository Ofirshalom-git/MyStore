using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

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
            try
            {
                Garbage = parentElement.FindElements(By.CssSelector(".icon-trash")).ToList();
                Price = parentElement.FindElements(By.CssSelector(".cart_total .price")).ToList();
                NumOfItems = parentElement.FindElements(By.CssSelector(".cart_quantity.text-center")).ToList();
                Quantity = base.parentElement.FindElement(By.CssSelector("#summary_products_quantity"));
            }

            catch
            {
                Quantity = base.parentElement.FindElement(By.CssSelector(".alert.alert-warning"));
            }
        }

        public int GetQuantity()
        {
            var quantity = Quantity.Text;

            if (Quantity.Text == "Your shopping cart is empty.")
            {
                return 0;
            }
            
            var NumOfProducts = new List<char>();
            for(var i = 0; i < quantity.Length; i++)
            {
                if(quantity[i] == ' ')
                {
                    break;
                }

                NumOfProducts.Add(quantity[i]);
            }

            return int.Parse(new string(NumOfProducts.ToArray()));
        }
    }
}
