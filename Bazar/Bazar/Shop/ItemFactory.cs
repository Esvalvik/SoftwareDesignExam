using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class ItemFactory
	{
	    private ItemFactory()
	    {
	    }

	    static IFood GetBasicFood(int id, string name, float price)
	    {
            return new BasicFood(id, name, price);
	    }
	    static IFood GetBasicFoodWithCorn(int id, string name, float price)
	    {
            IFood originalFood = new BasicFood(id, name, price);
            return new DecoratorFoodCorn(originalFood);
	    }

	    static IFood GetBasicFoodWithRice(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodRice(originalFood);
	    }

	    static IFood GetBasicFoodWithRawSauce(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodRawSauce(originalFood);
	    }

	    static IFood GetBasicFoodWithFries(int id, string name, float price)
	    {
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodFries(originalFood);
	    }

	    static IFood GetRandomDecoratedFood(int id)
	    {
            //TODO: Make random decorated food
	        IFood originalFood = new BasicFood(id, name, price);
	        return new DecoratorFoodCorn(originalFood);
	    }
    }
}
