using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class ColorRow : ComppenantBase
    {
        public List<Button> Colors => ParentElement.FindElements(By.CssSelector("ul.color_to_pick_list.clearfix")).Select(element => new Button(Driver, element)).ToList();

        public ColorRow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }
    }
}
