using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2LinkedListCode
{
    class Employee
    {
        string lastname;
        string firstname;
        int idNumber;

        public Employee(string l, string f, int i)
        {
            idNumber = i;
            lastname = l;
            firstname = f;
        }

        public static bool operator <(Employee p1, Employee p2)
        {
            if (p1.ID.CompareTo(p2.ID) < 0)
                return true;
            return false;
        }
        public static bool operator >(Employee p1, Employee p2)
        {
            if (p1.ID.CompareTo(p2.ID) <= 0)
                return false;
            return true;
        }

        public int ID
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public override string ToString()
        {
            return lastname + ", " + firstname + ", " + idNumber + ";";
        }

    }
}
