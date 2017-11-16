using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
    class Customer
	{
        #region Properties
        public int ID { get; private set; }
	    public string Name { get; private set; }

	    public List<IFood> OwnedItemsList { get; set; }
        #endregion

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

	    #region Methods

        /// <summary>
        /// Returns an array with the customers purchased items
        /// </summary>
        /// <returns></returns>
	    public IFood[] FetchItems()
	    {
	        return OwnedItemsList.ToArray();
	    }

        /// <summary>
        /// Adds the given item to the customers OwnedItemsList
        /// </summary>
        /// <param name="basicfood"></param>
	    public void ReceiveItem(IFood basicfood)
	    {
	        if (basicfood == null){ return; }
            OwnedItemsList.Add(basicfood);
	    }

		/// <summary>
		/// Returns the object as a string
		/// </summary>
		/// <returns></returns>
	    public override string ToString()
	    {
	        return ID + ":" + Name;
	    }

	    #endregion
    }
}
