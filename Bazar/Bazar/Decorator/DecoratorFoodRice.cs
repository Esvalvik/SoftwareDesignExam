namespace Bazar
{
    internal class DecoratorFoodRice : FoodDecorator
    {
        public DecoratorFoodRice(IFood iFoodOriginal) : base(iFoodOriginal)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " and rice";
        }

        public override float GetPrice()
        {
            return base.GetPrice() + 12.3f;
        }
    }
}