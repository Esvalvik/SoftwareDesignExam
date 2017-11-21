namespace Bazar
{
    internal class DecoratorFoodRawSauce : FoodDecorator
    {
        public DecoratorFoodRawSauce(IFood iFoodOriginal) : base(iFoodOriginal)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " and raw sauce";
        }

        public override float GetPrice()
        {
            return base.GetPrice() + 5f;
        }
    }
}