// a private method -called  "info hiding" is used in Contact... (THIS IS WHERE WE STARTED IN FORM DESIGN)

using System;

namespace ContactPrivateMethod
{
    public class Program
    {
        public static void Main()
        {
            Contact p1 = new Contact("Robert", 2693456789, 'W', true);
            Contact p2 = new Contact();
            Contact p3 = new Contact("Mary", 3871111, 'F', false);

            p1.ShowContactData();               // HOW ARE THESE METHODS DELCARED? PUBLIC OR PRIVATE??? 
            p2.ShowContactData();               //    DOES IT MATTER??
            p3.ShowContactData();
        }
    }
}


/*
 * Enter name:  Ethel
Enter phone (with area code like: 2693871000):  1234567890
Is he/she a Friend or Workmate?  Enter F or W:  f
Does he/she live in Kalamazoo?  Enter true or false:  FALSE


name:Robert, phone:2693456789, f/w:W, kzoo?:True

name:Ethel, phone:1234567890, f/w:f, kzoo?:False

name:Mary, phone:3871111, f/w:F, kzoo?:False

Press any key to continue . . .
*/