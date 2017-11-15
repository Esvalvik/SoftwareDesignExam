using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class ItemFactory
	{
	    private static Random _random;
	    private static readonly string[] itemNames = { "Chicken", "Lam", "Steak", "Pork" };
	    private static readonly float[] itemPrices = { 30f, 23f, 100f, 45f };
	    private ItemFactory()
	    {
	    }

	    public static IFood GetBasicFood(int id, string name, float price)
	    {
            return new BasicFood(id, name, price);
	    }
	    public static IFood GetBasicFoodWithCorn(int id, string name, float price)
	    {
            IFood originalFood = new BasicFood(id, name, price);
            return new DecoratorFoodCorn(originalFood);
	    }

	    public static IFood GetBasicFoodWithRice(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodRice(originalFood);
	    }

	    public static IFood GetBasicFoodWithRawSauce(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodRawSauce(originalFood);
	    }

	    public static IFood GetBasicFoodWithFries(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodFries(originalFood);
	    }

	   public static IFood GetRandomDecoratedFood(int id)
	    {
            //TODO: Clean up make code
	        _random = new Random();
            string name = itemNames[_random.Next(0, itemNames.Length - 1)];
	        float price = itemPrices[_random.Next(0, itemPrices.Length - 1)];
            IFood originalFood = new BasicFood(id, name, price);

	        for (int i = 0; i < _random.Next(0, 5); i++)
	        {
	            int randomDecoratorIndex = _random.Next(0, 3);
	            switch (randomDecoratorIndex)
	            {
                    case 0:
                        originalFood = new DecoratorFoodCorn(originalFood);
                        break;
	                case 1:
	                    originalFood = new DecoratorFoodFries(originalFood);
                        break;
	                case 2:
	                    originalFood = new DecoratorFoodRawSauce(originalFood);
                        break;
	                case 3:
	                    originalFood = new DecoratorFoodRice(originalFood);
                        break;
                }
	        }
	        return originalFood;
	    }
    }
}
