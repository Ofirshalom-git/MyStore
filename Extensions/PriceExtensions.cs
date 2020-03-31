using System.Collections.Generic;
using OpenQA.Selenium;

namespace Extensions
{
    public static class PriceExtensions
    {
        public static double[] GetPriceRange(IWebElement price)
        {
            var priceRange = price.Text;
            var lowestPrice = new List<char>();
            var highestPrice = new List<char>();
            int digit;
            bool passedFirstPrice = false;
            for (var i = 1; i < priceRange.Length; i++)
            {
                if (priceRange[i] == ' ')
                {
                    passedFirstPrice = true;
                }

                else if (int.TryParse(priceRange[i].ToString(), out digit) || priceRange[i] == '.')
                {
                    if (!passedFirstPrice)
                    {
                        lowestPrice.Add(priceRange[i]);
                    }

                    else
                    {
                        highestPrice.Add(priceRange[i]);
                    }
                }
            }

            var lowest = double.Parse(new string(lowestPrice.ToArray()));
            var highest = double.Parse(new string(highestPrice.ToArray()));

            return new double[2] { lowest, highest };
        }
    }
}
