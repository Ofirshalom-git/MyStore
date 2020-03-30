using OpenQA.Selenium;
using System.Linq;

namespace Infrastructure
{
    public class CatalogCategories : ComppenantBase
    {
        public Button Women => ParentElement.FindElements(By.CssSelector("#block_top_menu ul.sf-menu li a.sf-with-ul")).Select(element => new Button(Driver, element)).ToList()[0];
        public Button Dresses => ParentElement.FindElements(By.CssSelector("#block_top_menu ul.sf-menu li a.sf-with-ul")).Select(element => new Button(Driver, element)).FirstOrDefault(element => element.ToString().ToLower() == "dresses");
        public Button TShirts => ParentElement.FindElements(By.CssSelector("#block_top_menu ul.sf-menu li a.sf-with-ul")).Select(element => new Button(Driver, element)).FirstOrDefault(element => element.ToString().ToLower() == "t-shirts");

        public CatalogCategories(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }
       
        public CatalogPage ClickOnWomenCategory() =>
            Women.Click<CatalogPage>();
        public CatalogPage ClickOnDressesCategory() =>
            Dresses.Click<CatalogPage>();
        public CatalogPage ClickOnTShirtsCategory() =>
            TShirts.Click<CatalogPage>();
    }
}
