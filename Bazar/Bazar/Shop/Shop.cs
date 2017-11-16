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

		private const int _minValue = 1000;
		private const int _maxValue = 5000;
	    private int _createdItemsCount = 0;

        private ArrayList _availableItems;

	    private DateTime _dateTime;
		private Random _rnd = new Random();

		private double _lastTime;
		private long _itemCreationDelay;
		#endregion

		#region Constructors
		public Shop()
		{
			ID = 0;
			Name = "Unnamed";
			_availableItems = new ArrayList();
            _dateTime = new DateTime(1970, 1, 1);
			UpdateTime();
		}

		public Shop(int id, string name)
		{
			ID = id;
			Name = name;
			_availableItems = new ArrayList();
		    _dateTime = new DateTime(1970, 1, 1); ;
            UpdateTime();
		}
		#endregion

		#region Methods

		private void AddItem(IFood item)
		{
			_availableItems.Add(item);
		}

	    public IFood SellItem(int index)
	    {
	        IFood soldItem = (IFood) _availableItems[index];
            _availableItems.RemoveAt(index);
	        return soldItem;
	    }

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

	    public void Update()
		{
		    if (_createdItemsCount <= 5)
            { 
                if ( (GetTimeInMillis() - _lastTime) >= _itemCreationDelay)
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
            _itemCreationDelay = _rnd.Next(_minValue, _maxValue);
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
