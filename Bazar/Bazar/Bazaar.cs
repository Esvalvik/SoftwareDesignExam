﻿using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Bazaar
{
    public class Bazaar
    {

		#region Fields

		private readonly object _lock;
		private readonly Output _out;
		private readonly ArrayList _shops;
		private readonly ArrayList _customers;
		private readonly Stopwatch _stopwatch;
		private readonly Random _rnd;

		private readonly long _updateDelayInMillis = 100;
		private readonly int _amountCustomers = 5;
		private readonly int _amountShops = 3;
		private readonly bool _bazaarRunning = true;

		#endregion

		public Bazaar()
        {
            _out = Output.GetInstance();
            _shops = new ArrayList();
            _customers = new ArrayList();
            _stopwatch = new Stopwatch();
            _lock = new object();
            _rnd = new Random();
        }

        #region Methods

        /// <summary>
        ///     Initializes the bazar
        /// </summary>
        public void Init()
        {
			for(int i = 0; i < _amountShops; i++)
			{
				_shops.Add(new Shop(i, StaticData.ShopNames[i]));
			}

			for(int i = 0; i < _amountCustomers; i++)
			{
				_customers.Add(new Customer(i, StaticData.CustomerNames[i]));
			}

            _stopwatch.Start();
            Update();
        }

        /// <summary>
        ///     Update loop running every 100ms
        /// </summary>
        public void Update()
        {
            while (_bazaarRunning)
            {
				if(_stopwatch.ElapsedMilliseconds < _updateDelayInMillis)
				{
					continue;
				}

                //Add items
                foreach (Shop shop in _shops)
                {
                    var shopThread = new Thread(delegate() { shop.Update(); });
                    shopThread.Start();
                }

                var customerThreads = new Thread[_customers.Count];
                for (var i = 0; i < _customers.Count; i++)
                {
                    var index = i;
                    customerThreads[index] = new Thread(delegate()
                    {
                        CustomerSearchForFood((Customer) _customers[index]);
                    });
                }

                // Shuffle the thread array before starting threads
                customerThreads = customerThreads.OrderBy(x => _rnd.Next()).ToArray();
				foreach(var thread in customerThreads)
				{
					thread.Start();
				}
                _stopwatch.Restart();
            }
        }

        /// <summary>
        ///     Makes a customer go through the market searching for food items
        /// </summary>
        /// <param name="customer"></param>
        private void CustomerSearchForFood(Customer customer)
        {
			if(customer == null)
			{
				return;
			}

            foreach (Shop shop in _shops)
            {
				if(MakeTransaction(customer, shop))
				{
					break;
				}
            }
        }

        /// <summary>
        ///     Takes care of the transaction between customer and shop
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="shop"></param>
        private bool MakeTransaction(Customer customer, Shop shop)
        {
            lock (_lock)
            {
				// If no items for sale, we leave
				if(!shop.HasItemsForSale())
				{
					return false;
				}

                var soldItem = shop.SellItem(0);
                customer.ReceiveItem(soldItem);
                _out.Write("\t" + customer.Name + " has bought " + soldItem.GetDescription() + " for " +
                           soldItem.GetPrice() + "kr. From " + shop.Name);
				return true;
            }
        }

        #endregion
    }
}