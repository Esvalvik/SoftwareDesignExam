using System;

namespace Bazar
{
    internal class Program
    {
		//private Bazar bazar;

        private static void Main(string[] args)
        {
            var bazar = new Bazar();
            bazar.Init();

            Console.ReadKey();
        }
    }
}