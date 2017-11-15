using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class DecoratorFoodRice : FoodDecorator
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
