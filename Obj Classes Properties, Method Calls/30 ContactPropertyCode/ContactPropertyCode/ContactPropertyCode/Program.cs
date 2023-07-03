// additional code in property set (same as previous for Main()

using System;

namespace ContactPropertyCode
{
    class Program
    {
        static void Main()
        {
            Contact p1 = new Contact("Robert", 2693456789, 'W', true);

            Contact p2 = new Contact();
            p2.GetDataFromUser();

            Contact p3 = new Contact("Mary", 3871111, 'F', false);

            p1.ShowContactData();
            p2.ShowContactData();
            p3.ShowContactData();
        }
    }
}

/*
 * Enter name:  Fred
Enter phone (with area code like: 2693871000):  9875551212
Is he/she a Friend or Workmate?  Enter F or W:  F
Does he/she live in Kalamazoo?  Enter true or false:  false


name:Robert, phone:2693456789, f/w:W, kzoo?:True

name:Fred, phone:9875551212, f/w:F, kzoo?:False

name:Mary, phone:0, f/w:F, kzoo?:False

Press any key to continue . . .
 * 
 */ 
