using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemRecursiveSortAssign1TLee
{
    class Item
    {
        private string _itemNameString;
        private int _itemQuantityInteger;
        private double _itemPriceDouble;
        private double _itemTotalPriceDouble;

        public Item(string passedName, int passedQuantity, double passedPrice)
        {
            Name = passedName;
            Quantity = passedQuantity;
            Price = passedPrice;
            TotalPrice = (double)_itemQuantityInteger * _itemPriceDouble;
        }

        public string Name
        {
            get { return _itemNameString; }
            set { _itemNameString = value; }
        }

        public int Quantity
        {
            get { return _itemQuantityInteger; }
            set { _itemQuantityInteger = value; }
        }

        public double Price
        {
            get { return _itemPriceDouble; }
            set { _itemPriceDouble = value; }
        }

        public double TotalPrice
        {
            get { return _itemTotalPriceDouble; }
            set { _itemTotalPriceDouble = value; }
        }
    }
}
