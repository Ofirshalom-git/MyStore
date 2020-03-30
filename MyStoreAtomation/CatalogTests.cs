using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using FluentAssertions;

//ReferenceTypeAssertions ==> for later assertions

namespace MyStoreAtomation
{
    [TestClass]
    public class CatalogTests : UnitTestBase
    {
        [TestMethod]
        public void AddToCartButtonPopsTest()
        {
            var threwExeption = false;
            try
            {
                //hover over item[0], try to access it's addToCart button, if it won't apper it will throw an exception.
                var button = CatalogPage.Items[0].HoverOnItemByIndex().Items[0].AddToCartButton;
            }

            catch
            {
                threwExeption = true;
            }

            threwExeption.Should().BeFalse();
        }
        
        [TestMethod]
        public void AddToCartButtonDisapeersTest()
        {
            var threwExeption = false;
            try
            {
                //hover over item[0]
                CatalogPage.Items[0].HoverOnItemByIndex();
                //hover over item[1]
                CatalogPage.Items[1].HoverOnItemByIndex();
                //try to access item[0] addToCart button, if it won't apper it will throw an exception.
                var button = CatalogPage.Items[0].HoverOnItemByIndex().Items[0].AddToCartButton;
            }

            catch
            {
                threwExeption = true;
            }

            threwExeption.Should().BeTrue();
        }

        [TestMethod]
        public void AddToCartButtonWorksTest()
        {
            //click on cart button to count items
            var preAddcartPage = CatalogPage.Header.CartButton.Click<CartPage>();
            var preAddAmount = preAddcartPage.CartTable.GetQuantity();
            //go to myStore
            var preCatalogPage = preAddcartPage.Header.MyStoreButton.Click<CatalogPage>();
            //add the Item[0] to cart
            var postCatalogPage = preCatalogPage.Items[0].HoverOnItemByIndex().Items[0].ClickAddToCart().BackToCatalogPage();
            //go to cart and count items
            var postAddAmount = postCatalogPage.Header.CartButton.Click<CartPage>().CartTable.GetQuantity();
            //num of items should be 1 more
            postAddAmount.Should().Be(preAddAmount+1);
        }

        [TestMethod]
        public void PickedItemColorAppersTest()
        {
            //save color's name by going to color filter and check what color by it's index 
            var pressedColor = CatalogPage.Items[0].OptionalColors.Colors[0].ToString();
            //click on this color
            CatalogPage.Items[0].OptionalColors.Colors[0].Click<CatalogPage>();
            //the picked color should be the same
            CatalogPage.Items[0].ViewButton.Click<ViewItemPage>().ViewItemRow.PickedColor.ToString().Should().Be(pressedColor);
        }

        [TestMethod]
        public void ColorFilterWorksTest()
        {
            //go to color filter & save the color's name by it's index
            var pickedColor = CatalogPage.Filters.ColorFilter[0].ToString();
            //click on the color and save the page to use it
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
            //change to moveable

            //go to price filter & save the price range
            var lowestPrice = CatalogPage.Filters.GerPriceRange()[0];
            var highestPrice = CatalogPage.Filters.GerPriceRange()[1];
            //check all items prices
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
            //change to moveable

            //go to price filter & save the price range
            var lowestPrice = CatalogPage.Filters.GerPriceRange()[0];
            var highestPrice = CatalogPage.Filters.GerPriceRange()[1];
            //check all items prices
            foreach (var item in CatalogPage.Items)
            {
                var price = item.GetPrice();
                price.Should().BeGreaterOrEqualTo(lowestPrice);
                price.Should().BeLessOrEqualTo(highestPrice);
            }

            //go to color filter & save the color's name by it's index
            var pickedColor = CatalogPage.Filters.ColorFilter[0].ToString();
            //click on the color and save the page to use it
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
