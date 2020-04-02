using OpenQA.Selenium;
using System.Collections.Generic;

namespace Extensions
{
    public static class QuantityExtensions
    {
        public static int GetQuantity(IWebElement quantityInfo)
        {

            var quantity = quantityInfo.Text;

            if (quantity == "Your shopping cart is empty.")
            {
                return 0;
            }

            var NumOfProducts = new List<char>();
            for (var i = 0; i < quantity.Length; i++)
            {
                if (quantity[i] == ' ')
                {
                    break;
                }

                NumOfProducts.Add(quantity[i]);
            }

            return int.Parse(new string(NumOfProducts.ToArray()));
        }
    }
}
