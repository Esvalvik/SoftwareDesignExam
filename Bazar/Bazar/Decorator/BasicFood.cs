namespace Bazaar
{
    public class BasicFood : IFood
    {
        private readonly string _description;
        private readonly float _price;

        public BasicFood(string description, float price)
        {
            _description = description;
            _price = price;
        }

        public string GetDescription()
        {
            return _description;
        }

        public float GetPrice()
        {
            return _price;
        }
    }
}