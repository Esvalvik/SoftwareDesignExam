using System;

namespace Bazaar
{
    internal class Program
    {

        private static void Main(string[] args)
        {
			Console.Title = "Bazaar of the Bizarre";
            var bazar = new Bazaar();
            bazar.Init();

            Console.ReadKey();
        }
    }
}