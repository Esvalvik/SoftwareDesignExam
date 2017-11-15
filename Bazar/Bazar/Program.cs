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

		    for (int i = 0; i < 50; i++)
		    {
		        IFood superduperchicken = ItemFactory.GetRandomDecoratedFood(0);
		        Console.WriteLine("Food: " + superduperchicken.GetDescription() + " Price: " + superduperchicken.GetPrice() + "kr.");
            }


            Console.ReadKey();
		}
	}
}