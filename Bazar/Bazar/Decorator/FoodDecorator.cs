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

        public virtual int GetId()
        {
            return _iFoodOriginal.GetId();
        }

        public virtual string GetName()
        {
            return _iFoodOriginal.GetName();
        }

        public virtual float GetPrice()
        {
            return _iFoodOriginal.GetPrice();
        }
    }
}
