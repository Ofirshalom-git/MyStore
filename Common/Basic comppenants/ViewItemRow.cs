using OpenQA.Selenium;

namespace Infrastructure
{
    public class ViewItemRow : ComppenantBase
    {
        public IWebElement PickedColor => ParentElement.FindElement(By.CssSelector(".selected a"));

        public ViewItemRow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }
    }
}
