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
        public int ID { get; set; }
	    public string Name { get; set; }

	    public List<Basicfood> OwnedItemsList { get; set; }
        #endregion

        #region Constructors
	    public Customer()
	    {
	        ID = 0;
	        Name = "Unnamed";
	        OwnedItemsList = new List<Basicfood>();
	    }

	    public Customer(int id, string name)
	    {
	        ID = id;
	        Name = name;
	        OwnedItemsList = new List<Basicfood>();
	    }
        #endregion

	    #region Methods

        /// <summary>
        /// Returns an array with the customers purchased items
        /// </summary>
        /// <returns></returns>
	    public Basicfood[] FetchItems()
	    {
	        return OwnedItemsList.ToArray();
	    }

        /// <summary>
        /// Adds the given item to the customers OwnedItemsList
        /// </summary>
        /// <param name="basicfood"></param>
	    public void ReceiveItem(Basicfood basicfood)
	    {
	        if (basicfood == null){ return; }
            OwnedItemsList.Add(basicfood);
	    }

	    public string ToString()
	    {
	        return ID + ":" + Name;
	    }

	    #endregion
    }
}
