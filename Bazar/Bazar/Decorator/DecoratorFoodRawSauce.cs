using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class DecoratorFoodRawSauce : FoodDecorator
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
