using OpenQA.Selenium;

namespace Infrastructure
{
    public class Quantity : ComponentBase
    {
        public IWebElement QuantityIncrease => parentElement.FindElement(By.CssSelector(".cart_quantity_input.form-control.grey"));
        public IWebElement QuantityDecrease => parentElement.FindElement(By.CssSelector(".cart_quantity_button.clearfix .button-minus"));
        public IWebElement QuantityByNumber => parentElement.FindElement(By.CssSelector(".cart_quantity_button.clearfix .button-plus"));

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
