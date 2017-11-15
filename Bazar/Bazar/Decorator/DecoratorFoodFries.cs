using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class DecoratorFoodFries : FoodDecorator
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
