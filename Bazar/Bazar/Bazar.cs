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
	public class Bazar
	{
	    #region Fields
        private readonly Object _lock;
	    private readonly Output _out;
		private readonly ArrayList _shops;
	    private readonly ArrayList _customers;
	    private readonly Stopwatch _stopwatch;
	    private readonly Random _rnd;

	    private readonly long _updateDelayInMillis = 100;
	    private readonly int _amountCustomers = 5;
	    private readonly int _amountShops = 5;
        private bool _bazaarRunning = true;
        #endregion

        public Bazar()
		{
		    _out = Output.GetInstance();
			_shops = new ArrayList();
		    _customers = new ArrayList();
		    _stopwatch = new Stopwatch();
		    _lock = new Object();
            _rnd = new Random();
		}

	    #region Methods
        /// <summary>
        /// Initializes the bazar
        /// </summary>
        public void Init()
		{
		    for (int i = 0; i < _amountShops; i++)
		    {
                _shops.Add(new Shop(i, StaticData.shopNames[_rnd.Next(0, StaticData.shopNames.Length-1)]));
		    }

		    for (int i = 0; i < _amountCustomers; i++)
		    {
		        _customers.Add(new Customer(i, StaticData.customerNames[_rnd.Next(0, StaticData.customerNames.Length - 1)]));
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

                // Shuffle the thread array before starting threads
		        customerThreads = customerThreads.OrderBy(x => _rnd.Next()).ToArray();
                foreach (Thread thread in customerThreads)
		        {
		            thread.Start();
		        }
		        _stopwatch.Restart();
            }
		}
        /// <summary>
        /// Makes a customer go through the market searching for food items
        /// </summary>
        /// <param name="customer"></param>
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
                _out.Write("\t" + customer.Name + " has bought " + soldItem.GetDescription() + " for " + soldItem.GetPrice() + "kr. From " + shop.Name);
            }
        }
	    #endregion
    }
}