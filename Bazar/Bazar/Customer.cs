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

    }
}
