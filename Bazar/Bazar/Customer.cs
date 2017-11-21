using System.Collections.Generic;

namespace Bazar
{
    internal class Customer
    {
        #region Constructors

        /* public Customer()
        {
            ID = 0;
            Name = "Unnamed";
            OwnedItemsList = new List<IFood>();
        }
        */
        public Customer(int id, string name)
        {
            ID = id;
            Name = name;
            OwnedItemsList = new List<IFood>();
        }

        #endregion

        #region Properties

        public int ID { get; }
        public string Name { get; }

        public List<IFood> OwnedItemsList { get; set; }

        #endregion

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
            if (basicfood == null) return;
            OwnedItemsList.Add(basicfood);
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