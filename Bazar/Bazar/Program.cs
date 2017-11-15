using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class Program
	{
		static void Main(string[] args)
		{
			Bazar bazar = new Bazar();
			bazar.Init();

            IFood chicken = new BasicFood(0, "Chicken", 30.4f);
            IFood superChciken = new DecoratorFoodRawSauce(chicken);
            IFood superduperchicken = new DecoratorFoodFries(superChciken);

            Console.WriteLine("Food: " + superduperchicken.GetDescription() + " Price: " + superduperchicken.GetPrice() + "kr.");


		    Console.ReadKey();
		}
	}
}