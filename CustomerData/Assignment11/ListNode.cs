using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment11
{
    class ListNode
    {
        private Customer data;
        private ListNode next;
        private ListNode previous;

        public ListNode(Customer dataValue) : this(dataValue, null, null) { }

        public ListNode(Customer dataValue, ListNode nextNode, ListNode previousNode)
        {
            data = dataValue;
            next = nextNode;
            previous = previousNode;
        }

        public ListNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public ListNode Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Customer Data
        {
            get { return data; }
            set { data = value; }
        }

    }
}
