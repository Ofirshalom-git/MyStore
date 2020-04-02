using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;

namespace MyStoreAtomation
{
    [TestClass]
    public class UnitTestBase
    {
        protected HomePage HomePage { get; private set; }
        protected CatalogPage CatalogPage { get; private set; }
        private IWebDriver driver { get; set; }


        [TestInitialize]
        public void Initializer()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            HomePage = new HomePage(driver);
            CatalogPage = HomePage.GoToCatalogPage();
        }

        [TestCleanup]
        public void Clean()
        {
            driver.Close();
        }
    }
}
