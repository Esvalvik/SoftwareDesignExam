﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	interface IFood
	{
	    int GetId();
	    string GetDescription();
	    float GetPrice();
	}
}
