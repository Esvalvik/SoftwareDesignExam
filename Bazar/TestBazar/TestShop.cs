using System;
using NUnit.Framework;
using Bazaar;

namespace TestBazar
{
	[TestFixture]
	public class TestShop
	{

		Shop _shop;
		//[Test]
		public TestShop()
		{
			_shop = new Shop(2, "TestShop");
		}	

		[Test]
		public void TestAddItem()
		{
			var food = ItemFactory.GetBasicFood("Chicken", 22.2f);
			_shop.AddItem(food);
			Assert.AreEqual(1, _shop.GetAvailableItemsCount());
		}

		[Test]
		public void TestHasItemsForSale()
		{
			Assert.AreEqual(true, _shop.HasItemsForSale());
		}

		public void TestSellItem()
		{
			_shop.SellItem(1);
			Assert.AreEqual(0, _shop.GetAvailableItemsCount());
		}
		
	}

}
