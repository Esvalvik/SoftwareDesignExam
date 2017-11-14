using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class Bazar
	{
	    private Output _out;
		public Bazar()
		{
		    _out = Output.GetInstance();
		}

		/// <summary>
		/// Initializes the bazar
		/// </summary>
		public void Init()
		{
            _out.Write("Hello from init");
		}
	}
}
