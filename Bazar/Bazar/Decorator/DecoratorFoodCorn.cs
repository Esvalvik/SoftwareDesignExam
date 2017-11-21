namespace Bazar
{
    internal class DecoratorFoodCorn : FoodDecorator
    {
        public DecoratorFoodCorn(IFood iFoodOriginal) : base(iFoodOriginal)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " and corn";
        }

        public override float GetPrice()
        {
            return base.GetPrice() + 8.5f;
        }
    }
}