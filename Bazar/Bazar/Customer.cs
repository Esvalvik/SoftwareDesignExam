using System.Collections.Generic;

namespace Bazaar
{
    internal class Customer
    {

		#region Properties

		public int ID { get; private set; }
		public string Name { get; private set; }

		public List<IFood> OwnedItemsList { get; set; }

		#endregion

		public Customer(int id, string name)
        {
            ID = id;
            Name = name;
            OwnedItemsList = new List<IFood>();
        }

		#region Methods

		/// <summary>
		///     Returns an array with the customers purchased items
		/// </summary>
		/// <returns></returns>
		public IFood[] FetchItems()
        {
            return OwnedItemsList.ToArray();
        }

        /// <summary>
        ///     Adds the given item to the customers OwnedItemsList
        /// </summary>
        /// <param name="basicfood"></param>
        public void ReceiveItem(IFood basicfood)
        {
			if(basicfood != null)
			{
				OwnedItemsList.Add(basicfood);
			}
        }

        /// <summary>
        ///     Returns the object as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ID + ":" + Name;
        }
        #endregion
    }
}