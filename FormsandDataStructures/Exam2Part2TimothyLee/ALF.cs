using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam2Part2TimothyLee
{
    class ALF
    {
        private string name;
        private int age;
        private string homeplanet;

        public ALF() { }
        public ALF(string n, string h, int a)
        {
            name = n; homeplanet = h; age = a;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Homeplanet
        {
            get { return homeplanet; }
            set { homeplanet = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return Name + " : " + homeplanet + " : " + Age;
        }
    }
}
