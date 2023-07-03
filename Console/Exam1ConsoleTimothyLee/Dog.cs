using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam1ConsoleTimothyLee
{
    class Dog:Pet
    {
        private int age;
        private double weight;

        public Dog(): base()
        {
        }

        public Dog(string n): base(n)
        {
            Name = n;
        }

        public Dog(string n, int a, double w): base(n)
        {
            Age = a;
            Weight = w;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "  This Dog Weighs: " + Weight.ToString(); // It IS seperated with a : technically
        }
    }
}
