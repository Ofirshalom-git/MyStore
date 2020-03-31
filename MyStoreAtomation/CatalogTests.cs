using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using FluentAssertions;

namespace MyStoreAtomation
{
    [TestClass]
    public class CatalogTests : UnitTestBase
    {
        [TestMethod]
        public void AddToCartButtonPopsTest()
        {
            CatalogPage.Items[0].HoverOnItemByIndex().Items[0].AddToCartButton.IsEnabled().Should().BeTrue();
        }
        
        [TestMethod]
        public void AddToCartButtonDisapearsTest()
        {
                CatalogPage.Items[0].HoverOnItemByIndex();
                CatalogPage.Items[1].HoverOnItemByIndex();
                CatalogPage.Items[0].AddToCartButton.IsEnabled().Should().BeFalse();
        }

        [TestMethod]
        public void AddToCartButtonWorksTest()
        {
            var preAddcartPage = CatalogPage.Header.CartButton.Click<CartPage>();
            var preAddAmount = preAddcartPage.CartTable.GetQuantity();
            var preCatalogPage = preAddcartPage.Header.MyStoreButton.Click<CatalogPage>();
            var postCatalogPage = preCatalogPage.Items[0].HoverOnItemByIndex().Items[0].ClickAddToCart().BackToCatalogPage();
            var postAddAmount = postCatalogPage.Header.CartButton.Click<CartPage>().CartTable.GetQuantity();
            postAddAmount.Should().Be(preAddAmount+1);
        }

        [TestMethod]
        public void PickedItemColorAppersTest()
        {
            var pressedColor = CatalogPage.Items[0].OptionalColors.Colors[0].ToString();
            CatalogPage.Items[0].OptionalColors.Colors[0].Click<CatalogPage>();
            CatalogPage.Items[0].ViewButton.Click<ViewItemPage>().ViewItemRow.PickedColor.ToString().Should().Be(pressedColor);
        }

        [TestMethod]
        public void ColorFilterWorksTest()
        {
            var pickedColor = CatalogPage.Filters.ColorFilter[0].ToString();
            var postCatalogPage = CatalogPage.Filters.ColorFilter[0].Click<CatalogPage>();
            foreach(var item in postCatalogPage.Items)
            {
                var quickView = item.ClickQuickView();
                quickView.PickedColor.Should().Equals(pickedColor);
                quickView.CloseButton.Click<CatalogPage>();                
            }
        }

        [TestMethod]
        public void PriceRangeFilterWorksTest()
        {
            var lowestPrice = CatalogPage.Filters.GerPriceRange()[0];
            var highestPrice = CatalogPage.Filters.GerPriceRange()[1];
            foreach (var item in CatalogPage.Items)
            {
                var price = item.GetPrice();
                price.Should().BeGreaterOrEqualTo(lowestPrice);
                price.Should().BeLessOrEqualTo(highestPrice);
            }
        }

        [TestMethod]
        public void PriceAndColorFilterWorksTest()
        {
            var lowestPrice = CatalogPage.Filters.GerPriceRange()[0];
            var highestPrice = CatalogPage.Filters.GerPriceRange()[1];
            foreach (var item in CatalogPage.Items)
            {
                var price = item.GetPrice();
                price.Should().BeGreaterOrEqualTo(lowestPrice);
                price.Should().BeLessOrEqualTo(highestPrice);
            }

            var pickedColor = CatalogPage.Filters.ColorFilter[0].ToString();
            var postCatalogPage = CatalogPage.Filters.ColorFilter[0].Click<CatalogPage>();
            foreach (var item in postCatalogPage.Items)
            {
                var quickView = item.ClickQuickView();
                quickView.PickedColor.Should().Equals(pickedColor);
                quickView.CloseButton.Click<CatalogPage>();
            }
        }

        [TestMethod]
        public void ViewedItemAppersInListTest()
        {
            var condition = false;
            var itemName = CatalogPage.Items[0].Name.ToString();
            var postViewCatalogPage = CatalogPage.Items[0].ClickQuickView().CloseButton.Click<CatalogPage>();
            foreach(var name in postViewCatalogPage.ViewedItemsName)
            {
                if(name.Text == itemName)
                {
                    condition = true;
                }
            }

            condition.Should().BeTrue();
        }
    }
}
