namespace Bazar
{
    internal class DecoratorFoodFries : FoodDecorator
    {
        public DecoratorFoodFries(IFood iFoodOriginal) : base(iFoodOriginal)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " and fries";
        }

        public override float GetPrice()
        {
            return base.GetPrice() + 14.7f;
        }
    }
}