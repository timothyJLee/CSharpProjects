// extra properties, Convert's

using System;

namespace ContactExtraProp
{
    class Program
    {
        static void Main()
        {
            // NOTE:  THESE ARE NOW ALL STRING PARAMETERS

            Contact p1 = new Contact(
                "Robert", "Smith", "269", "3456789", "W", "yes");
            Contact p2 = new Contact(
                "Mary",   "Jones", "616", "3871111", "F", "no");

            p1.ShowContactData();
            p2.ShowContactData();

            Console.WriteLine("p1's full name:  {0}", p1.Name);
            Console.WriteLine("p2's full name:  {0}", p2.Name);
        }
    }
}


/*  OUTPUT:
 This year is 2012

name: Robert Smith, (first name: Robert, last name Smith)
phone: 2693456789, (area code: 269)
Friend or Workmate: W
Live in Kalamazoo: True

This year is 2012

name: Mary Jones, (first name: Mary, last name Jones)
phone: 6163871111, (area code: 616)
Friend or Workmate: F
Live in Kalamazoo: False

p1's full name:  Robert Smith
p2's full name:  Mary Jones
Press any key to continue . . .

*/