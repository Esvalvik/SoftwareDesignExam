using System;

namespace Bazar
{
    internal class Program
    {
        public Bazar Bazar
        {
            get => default(Bazar.Bazar);
            set
            {
            }
        }

        private static void Main(string[] args)
        {
            var bazar = new Bazar();
            bazar.Init();

            Console.ReadKey();
        }
    }
}