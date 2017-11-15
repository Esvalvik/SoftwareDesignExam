using System;
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

		private List<Item> _availableItems;

		private Random _rnd = new Random();

		private long _lastTime;
		private long _itemCreationDelay;
		#endregion

		#region Constructors
		public Shop()
		{
			ID = 0;
			Name = "Unnamed";
			_availableItems = new List<Item>();
			UpdateTime();
		}

		public Shop(int id, string name)
		{
			ID = id;
			Name = name;
			_availableItems = new List<Item>();
			UpdateTime();
		}
		#endregion

		#region Methods

		private void AddItem(Item item)
		{
			_availableItems.Add(item);
		}

		public void Update()
		{
			if((System.DateTime.Now.Millisecond - _lastTime) >= _itemCreationDelay)
			{
				//Item newItem = ItemFactory.CreateItem(_rnd.Next(0, 9);
				UpdateTime();
			}
		}

		private void UpdateTime()
		{
			_lastTime = System.DateTime.Now.Millisecond;
			_itemCreationDelay = _rnd.Next(_minValue, _maxValue);
		}


		#endregion
	}
}
