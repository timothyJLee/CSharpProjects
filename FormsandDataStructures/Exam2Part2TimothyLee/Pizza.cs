using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam2Part2TimothyLee
{
    class Pizza
    {
        private double size;
        private int numToppings;


        public Pizza() { }
        public Pizza(double s, int n)
        {
            size = s; numToppings = n;
        }


        public static bool operator ==(Pizza p1, Pizza p2)
        {
            if (p1.Size.CompareTo(p2.Size) != 0 && p1.numToppings.CompareTo(p2.numToppings) != 0)
                    return false;
            return true;
        }
        public static bool operator !=(Pizza p1, Pizza p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }


        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public int NumberofToppings
        {
            get { return numToppings; }
            set { numToppings = value; }
        }

        public override string ToString()
        {
            return size + " : " + numToppings;
        }
    }
}
