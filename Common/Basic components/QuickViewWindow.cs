using OpenQA.Selenium;

namespace Infrastructure
{
    public class QuickViewWindow : ComponentBase
    {
        public Button CloseButton => new Button(driver, driver.FindElement(By.CssSelector("a.fancybox-item.fancybox-close")));
        public IWebElement PickedColor => driver.FindElement(By.CssSelector("#color_to_pick_list .selected a"));

        public QuickViewWindow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }
    }
}
