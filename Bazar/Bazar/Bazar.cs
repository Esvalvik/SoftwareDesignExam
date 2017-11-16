using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	    private Stopwatch _stopwatch;
	    private long _updateDelayInMillis = 100;
            
		public Bazar()
		{
		    _out = Output.GetInstance();
			_shops = new List<Shop>();
		    _stopwatch = new Stopwatch();
		}

		/// <summary>
		/// Initializes the bazar
		/// </summary>
		public void Init()
		{
            _out.Write("Hello from init");
            _stopwatch.Start();
            Update();
		}

        /// <summary>
        /// Update loop running every 100ms
        /// </summary>
		public void Update()
		{
		    while (_bazaarRunning)
		    {
                if(_stopwatch.ElapsedMilliseconds < _updateDelayInMillis) { continue; }

                IFood superduperchicken = ItemFactory.GetRandomDecoratedFood();
		        Console.WriteLine("Food: " + superduperchicken.GetDescription() + " Price: " + superduperchicken.GetPrice() + "kr.");
                
                _stopwatch.Restart();
            }
		}
	}
}
