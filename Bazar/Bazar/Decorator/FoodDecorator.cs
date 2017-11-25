namespace Bazaar
{
    internal abstract class FoodDecorator : IFood
    {
        private readonly IFood _iFoodOriginal;

        protected FoodDecorator(IFood iFoodOriginal)
        {
            _iFoodOriginal = iFoodOriginal;
        }

        public virtual string GetDescription()
        {
            return _iFoodOriginal.GetDescription();
        }

        public virtual float GetPrice()
        {
            return _iFoodOriginal.GetPrice();
        }
    }
}