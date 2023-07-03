using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment11
{
    abstract class Customer
    {
        private string name;
        private int age;



        public Customer(string nameInput, int ageInput)
        {
            name = nameInput; age = ageInput;
        }


        public static bool operator <(Customer p1, Customer p2)
        {
            return (p1.Age < p2.Age);
        }
        public static bool operator >(Customer p1, Customer p2)
        {
            return (p1.Age > p2.Age);
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public abstract override string ToString();
    }
}
