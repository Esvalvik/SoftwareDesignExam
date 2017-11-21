using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	class Shop
	{
		#region Fields
		
		public int ID { get; private set; }

		public string Name { get; private set; }

		private readonly int MIN_VALUE = 1000;
		private readonly int MAX_VALUE = 5000;
	    private readonly int MAX_ITEMS = 5;
	    private int _createdItemsCount = 0;

        private readonly ArrayList _availableItems;

	    private DateTime _dateTime;
	    private readonly Random _rnd;
	    private readonly Output _out;

		private double _lastTime;
		private long _itemCreationDelay;
		#endregion

		#region Constructors
		/*public Shop()
		{
			ID = 0;
			Name = "Unnamed";
			_availableItems = new ArrayList();
            _dateTime = new DateTime(1970, 1, 1);
            _rnd = new Random();;
            UpdateTime();
		}
        */
		public Shop(int id, string name)
		{
			ID = id;
			Name = name;
			_availableItems = new ArrayList();
		    _dateTime = new DateTime(1970, 1, 1);
            _rnd = new Random();
		    _out = Output.GetInstance();
            UpdateTime();
		}
		#endregion

		#region Methods

        /// <summary>
        /// Adds given item to the available array
        /// </summary>
        /// <param name="item"></param>
		private void AddItem(IFood item)
		{
			_availableItems.Add(item);
            _out.Write(Name + " put " + item.GetDescription() + " up for sale!");
		}

        /// <summary>
        /// Returns item from index and removes it from available array
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
	    public IFood SellItem(int index)
	    {
	        IFood soldItem = (IFood) _availableItems[index];
            _availableItems.RemoveAt(index);
	        return soldItem;
	    }

        /// <summary>
        /// Returns an array of available items
        /// </summary>
        /// <returns></returns>
	    public IFood[] GetAvailableItems()
	    {
	        return (IFood[]) _availableItems.ToArray();
	    }

        /// <summary>
        /// Returns whether their are items for sale or not
        /// </summary>
        /// <returns></returns>
	    public bool HasItemsForSale()
	    {
	        return _availableItems.Count > 0 ? true : false;
	    }

        /// <summary>
        /// Shops update loop, creating new items after random interval
        /// </summary>
	    public void Update()
		{
		    if (_createdItemsCount < MAX_ITEMS)
            { 
                if ((GetTimeInMillis() - _lastTime) >= _itemCreationDelay)
		        {
		            AddItem(ItemFactory.GetRandomDecoratedFood());
		            _createdItemsCount++;
		            UpdateTime();
		        }
            }
		}

        /// <summary>
        /// Updates lastTime and sets a random item creation delay
        /// </summary>
		private void UpdateTime()
		{
		    _lastTime = GetTimeInMillis();
            _itemCreationDelay = _rnd.Next(MIN_VALUE, MAX_VALUE);
		}

        /// <summary>
        /// Gives the time in milliseconds
        /// </summary>
        /// <returns></returns>
	    private long GetTimeInMillis()
	    {
	        return (long) DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
	    }

        #endregion
    }
}
