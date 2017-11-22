using System;

namespace Bazar
{
    public class ItemFactory
    {
        private static readonly Random _random;

        static ItemFactory()
        {
            _random = new Random();
        }

        /// <summary>
        ///     Creates a basicFood object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static IFood GetBasicFood(string name, float price)
        {
            return new BasicFood(name, price);
        }

        /// <summary>
        ///     Craetes a basicFood object with corn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static IFood GetBasicFoodWithCorn(string name, float price)
        {
            IFood originalFood = new BasicFood(name, price);
            return new DecoratorFoodCorn(originalFood);
        }

        /// <summary>
        ///     Craetes a basicFood object with Rice
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static IFood GetBasicFoodWithRice(string name, float price)
        {
            IFood originalFood = new BasicFood(name, price);
            return new DecoratorFoodRice(originalFood);
        }

        /// <summary>
        ///     Craetes a basicFood object with RawSauce
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static IFood GetBasicFoodWithRawSauce(string name, float price)
        {
            IFood originalFood = new BasicFood(name, price);
            return new DecoratorFoodRawSauce(originalFood);
        }

        /// <summary>
        ///     Craetes a basicFood object with Fries
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static IFood GetBasicFoodWithFries(string name, float price)
        {
            IFood originalFood = new BasicFood(name, price);
            return new DecoratorFoodFries(originalFood);
        }

        /// <summary>
        ///     Creates a basicFood object with random decorations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IFood GetRandomDecoratedFood()
        {
            var randomIndex = _random.Next(0, StaticData.ItemNames.Length - 1);
            var name = StaticData.ItemNames[randomIndex];
            var price = StaticData.ItemPrices[randomIndex];
            IFood originalFood = new BasicFood(name, price);

            for (var i = 0; i < _random.Next(0, 5); i++)
            {
                var randomDecoratorIndex = _random.Next(0, 3);
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