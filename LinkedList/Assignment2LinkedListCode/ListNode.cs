using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2LinkedListCode
{
    class ListNode
    {
        private Employee data;             
        private ListNode next;

        public ListNode() : this(null, null) { }
		
		public ListNode( Employee dataValue ) : this( dataValue, null)  {}
        		      
		public ListNode( Employee dataValue, ListNode nextNode)
        { data = dataValue; next = nextNode;}

        public static bool operator <(ListNode p1, ListNode p2)
        {
            if (p1.data.ID.CompareTo(p2.data.ID) < 0)
                return true;
            return false;
        }
        public static bool operator >(ListNode p1, ListNode p2)
        {
            if (p1.data.ID.CompareTo(p2.data.ID) <= 0)
                return false;
            return true;
        }

        public ListNode Next
        { get { return next; } set { next = value; } }
 
		public Employee Data
        {  get  { return data; } set { data = value; } } 

    }
}
