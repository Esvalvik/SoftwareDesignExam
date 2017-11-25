using System;
using NUnit.Framework;
using Bazaar;

namespace TestBazar
{
	[TestFixture]
	public class TestItemFactory
	{
		[Test]
		public void TestGetBasicFood()
		{
			IFood food = ItemFactory.GetBasicFood("Steak", 32.5f);
			Assert.AreEqual(32.5f, food.GetPrice());
			Assert.AreEqual("Steak", food.GetDescription());
		}

		[Test]
		public void TestGetBasicFoodWithCorn()
		{
			IFood food = ItemFactory.GetBasicFoodWithCorn("Chicken", 45.4f);
			Assert.AreEqual(53.9f, food.GetPrice());
			Assert.AreEqual("Chicken and corn", food.GetDescription());
		}

		[Test]
		public void TestGetBasicFoodWithRice()
		{
			IFood food = ItemFactory.GetBasicFoodWithRice("Chicken", 12.3f);
			Assert.AreEqual(24.6f, food.GetPrice());
			Assert.AreEqual("Chicken and rice", food.GetDescription());
		}

		[Test]
		public void TestGetBasicFoodWithFries()
		{
			IFood food = ItemFactory.GetBasicFoodWithFries("Chicken", 15.3f);
			Assert.AreEqual(30f, food.GetPrice());
			Assert.AreEqual("Chicken and fries", food.GetDescription());
		}

		[Test]
		public void TestGetBasicFoodWithRawSauce()
		{
			IFood food = ItemFactory.GetBasicFoodWithRawSauce("Chicken", 14.3f);
			Assert.AreEqual(19.3f, food.GetPrice());
			Assert.AreEqual("Chicken and raw sauce", food.GetDescription());
		}
	}
}
