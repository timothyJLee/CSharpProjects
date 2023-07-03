using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam1ConsoleTimothyLee
{
    class Customer
    {
        private int id;
        private string name;

        public Customer() { }

        public Customer(string n, int id)
        {
            Name = n;
            ID = id;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return "Name of Customer Number: " + id + " is " + name + ".";
        }
    }
}
