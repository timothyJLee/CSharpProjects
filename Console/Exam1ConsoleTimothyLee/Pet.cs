using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam1ConsoleTimothyLee
{
    class Pet
    {
        private string name;

        public Pet() { }
        public Pet(string n) { name = n; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return ("Pet name = " + name);
        }
    }
}
