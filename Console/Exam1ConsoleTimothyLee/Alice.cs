using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam1ConsoleTimothyLee
{
    class Alice : Human
    {
        private double height;
        private string birthMonth;

        public Alice() : base() { }
        public Alice(string f, string n, int y, double h, string b)
            : base(f, n, y)
        {
            FirstName = f; LastName = n; YearBorn = y; Height = h; BirthMonth = b;
        }

        public string BirthMonth
        {
            get { return birthMonth; }
            set { birthMonth = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public override int FindAge()
        {
            return (2009 - YearBorn);
        }

        public override string ToString()
        {
            return FirstName + ":" + LastName + ":" + YearBorn + ":" + Height + ":" + BirthMonth + ".";
        }
    }
}
