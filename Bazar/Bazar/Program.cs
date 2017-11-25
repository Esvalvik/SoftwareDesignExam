using System;

namespace Bazaar
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            var bazar = new Bazaar();
            bazar.Init();

            Console.ReadKey();
        }
    }
}