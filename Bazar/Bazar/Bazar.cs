using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bazar
{
	class Bazar
	{
	    private readonly Object _lock;
	    private Output _out;
		private ArrayList _shops;
	    private ArrayList _customers;
	    private bool _bazaarRunning = true;
	    private Stopwatch _stopwatch;
	    private long _updateDelayInMillis = 100;
            
		public Bazar()
		{
		    _out = Output.GetInstance();
			_shops = new ArrayList();
		    _customers = new ArrayList();
		    _stopwatch = new Stopwatch();
		    _lock = new Object();
		}

		/// <summary>
		/// Initializes the bazar
		/// </summary>
		public void Init()
		{
            _out.Write("Hello from init");

		    for (int i = 0; i < 5; i++)
		    {
                _shops.Add(new Shop(i, "Shop_" + i));
		    }

		    for (int i = 0; i < 5; i++)
		    {
		        _customers.Add(new Customer(i, "Alibaba_" + i));
		    }

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

                //Add items
		        foreach (Shop shop in _shops)
		        {
		            Thread shopThread = new Thread(delegate() { shop.Update(); });
		            shopThread.Start();
		        }

                Thread[] customerThreads = new Thread[_customers.Count];
		        for (int i = 0; i < _customers.Count; i++)
		        {
		            int index = i;
                    customerThreads[index] = new Thread(delegate()
                    {
                        CustomerSearchForFood((Customer)_customers[index]);
                    });
		        }

		        foreach (Thread thread in customerThreads)
		        {
		            thread.Start();
		        }
		        _stopwatch.Restart();
            }
		}

	    private void CustomerSearchForFood(Customer customer)
	    {
	        if (customer == null)
	        {
	            return; 
	        }

	        foreach (Shop shop in _shops)
	        {
	            Thread thread = new Thread((delegate () { MakeTransaction(customer, shop); }));
                thread.Start();
            }
        }

	    /// <summary>
        /// Takes care of the transaction between customer and shop
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="shop"></param>
	    private void MakeTransaction(Customer customer, Shop shop)
        {
            lock (_lock)
            {
                // If no items for sale, we leave
                if (!shop.HasItemsForSale())
                {
                    return;
                }

                IFood soldItem = shop.SellItem(0);
                customer.ReceiveItem(soldItem);
                _out.Write(customer.Name + " has bought " + soldItem.GetDescription() + " for " + soldItem.GetPrice() + "kr. From " + shop.Name);
            }
        }
	}
}
