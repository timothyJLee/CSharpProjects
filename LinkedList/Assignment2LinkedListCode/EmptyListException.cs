using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2LinkedListCode
{
    class EmptyListException : ApplicationException
    {
        public EmptyListException(string name)
            : base("The " + name + " is empty") { }  // end constructor
    }
}
