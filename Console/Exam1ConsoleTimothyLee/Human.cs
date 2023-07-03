using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam1ConsoleTimothyLee
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;
        private int yearBorn;


        public Human() { }

        public Human(string f, string n, int y)
        {
            firstName = f; lastName = n; yearBorn = y;
        }


        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int YearBorn
        {
            get { return yearBorn; }
            set { yearBorn = value; }
        }


        public abstract int FindAge();

    }
}
