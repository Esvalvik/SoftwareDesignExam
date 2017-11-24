using System;
using NUnit.Framework;
using Bazar;

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
	}

}
