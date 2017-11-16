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
	    static ItemFactory()
	    {
	        _random = new Random();
	    }

        /// <summary>
        /// Creates a basicFood object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
	    public static IFood GetBasicFood(int id, string name, float price)
	    {
            return new BasicFood(id, name, price);
	    }

        /// <summary>
        /// Craetes a basicFood object with corn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
	    public static IFood GetBasicFoodWithCorn(int id, string name, float price)
	    {
            IFood originalFood = new BasicFood(id, name, price);
            return new DecoratorFoodCorn(originalFood);
	    }
	    /// <summary>
	    /// Craetes a basicFood object with Rice
	    /// </summary>
	    /// <param name="id"></param>
	    /// <param name="name"></param>
	    /// <param name="price"></param>
	    /// <returns></returns>
	    public static IFood GetBasicFoodWithRice(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodRice(originalFood);
	    }

	    /// <summary>
	    /// Craetes a basicFood object with RawSauce
	    /// </summary>
	    /// <param name="id"></param>
	    /// <param name="name"></param>
	    /// <param name="price"></param>
	    /// <returns></returns>
	    public static IFood GetBasicFoodWithRawSauce(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodRawSauce(originalFood);
	    }

	    /// <summary>
	    /// Craetes a basicFood object with Fries
	    /// </summary>
	    /// <param name="id"></param>
	    /// <param name="name"></param>
	    /// <param name="price"></param>
	    /// <returns></returns>
	    public static IFood GetBasicFoodWithFries(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodFries(originalFood);
	    }

        /// <summary>
        /// Creates a basicFood object with random decorations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
	   public static IFood GetRandomDecoratedFood(int id)
	    {
            //TODO: Clean up make code
	        int randomIndex = _random.Next(0, itemNames.Length - 1);
            string name = itemNames[randomIndex];
	        float price = itemPrices[randomIndex];
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
