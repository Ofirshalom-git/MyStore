using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class Filters : ComponentBase
    {
        public List<Button> ColorFilter => parentElement.FindElements(By.CssSelector("#ul_layered_id_attribute_group_3 li")).Select(element => new Button(driver, element)).ToList();
        public IWebElement PriceRange => parentElement.FindElement(By.CssSelector("#layered_price_range"));


        public Filters(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }

        public double[] GerPriceRange()
        {
            var priceRange = PriceRange.Text;
            var lowestPrice = new List<char>();
            var highestPrice = new List<char>();
            int digit;
            bool passedFirstPrice = false;
            for (var i = 1; i < priceRange.Length; i++)
            {
                if(priceRange[i] == ' ')
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
