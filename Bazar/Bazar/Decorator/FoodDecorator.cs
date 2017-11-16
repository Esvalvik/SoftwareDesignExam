using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
    abstract class FoodDecorator : IFood
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
