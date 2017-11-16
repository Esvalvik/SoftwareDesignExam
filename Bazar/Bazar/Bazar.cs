﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class Bazar
	{
	    private Output _out;
		private List<Shop> _shops;
	    private bool _bazaarRunning = true;
		public Bazar()
		{
		    _out = Output.GetInstance();
			_shops = new List<Shop>();
		}

		/// <summary>
		/// Initializes the bazar
		/// </summary>
		public void Init()
		{
            _out.Write("Hello from init");
		}

		public void Update()
		{
		    while (_bazaarRunning)
		    {
                //TODO: Add delay
                //Foreverlooop
            }
		}
	}
}
