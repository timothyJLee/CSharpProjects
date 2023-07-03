using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam2Part2TimothyLee
{
    class CartoonCharacter
    {
        private string name;
        private int id;

        public CartoonCharacter() { }
        public CartoonCharacter(string n, int i)
        {
            name = n; id = i;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return Name + " - " + id;
        }
    }
}
