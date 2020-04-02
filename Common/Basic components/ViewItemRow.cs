using OpenQA.Selenium;

namespace Infrastructure
{
    public class ViewItemRow : ComponentBase
    {
        public IWebElement PickedColor => parentElement.FindElement(By.CssSelector(".selected a"));

        public ViewItemRow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }
    }
}
