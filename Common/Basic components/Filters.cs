using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class Filters : ComponentBase
    {
        public List<Button> ColorFilter => ParentElement.FindElements(By.CssSelector("#ul_layered_id_attribute_group_3 li")).Select(element => new Button(Driver, element)).ToList();
        public IWebElement PriceRange => ParentElement.FindElement(By.CssSelector("#layered_price_range"));


        public Filters(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }

        public double[] GerPriceRange() =>
            Extensions.PriceExtensions.GetPriceRange(PriceRange);
        
    }
}
