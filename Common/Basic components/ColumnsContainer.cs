using OpenQA.Selenium;

namespace Infrastructure
{
    public class ColumnsContainer : ComponentBase
    {
        public IWebElement Columns => driver.FindElement(By.CssSelector(".columns-container"));

        public ColumnsContainer(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }
    }
}
