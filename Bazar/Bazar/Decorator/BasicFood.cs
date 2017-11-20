using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
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
            return (float)_price;
        }
    }
}
