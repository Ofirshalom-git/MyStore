using OpenQA.Selenium;

namespace Infrastructure
{
    public class Quantity : ComppenantBase
    {
        public IWebElement QuantityIncrease => ParentElement.FindElement(By.CssSelector(".cart_quantity.text-center"));
        public IWebElement QuantityDecrease => ParentElement.FindElement(By.CssSelector(".cart_quantity.text-center"));
        public IWebElement QuantityByNumber => ParentElement.FindElement(By.CssSelector(".cart_quantity.text-center"));

        public Quantity(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {

        }

        public void IncreaseQuantityBy(int units) =>
            MultiplyClick(QuantityIncrease, units);
        
        public void DecreaseQuantityBy(int units) =>
            MultiplyClick(QuantityDecrease, units);
        
        public void ChangeQuantity(double units)
        {
            QuantityByNumber.Clear();
            QuantityByNumber.SendKeys(units.ToString());
        }

        private void MultiplyClick(IWebElement element, int count)
        {
            for (var i = 0; i < count; i++)
            {
                element.Click();
            }
        }
    }
}
