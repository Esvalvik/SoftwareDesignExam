using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
    public class BasicFood : IFood
    {
        private readonly int _id;
        private readonly string _description;
        private readonly float _price;

        public BasicFood(int id, string description, float price)
        {
            _id = id;
            _description = description;
            _price = price;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetId()
        {
            return _id;
        }

        public float GetPrice()
        {
            return _price;
        }
    }
}
