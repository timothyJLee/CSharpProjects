//  additional code in property get - Main() is same as before - instantiates 3 instances of Contact
//      person1 (p1), person2 (p2), and person3 (p3)

using System;

namespace ContactPropertyGet
{
    public class Program
    {
        public static void Main()
        {
            Contact p1 = new Contact("Robert", 2693456789, 'W', true);

            Contact p2 = new Contact();
            p2.GetDataFromUser();

            Contact p3 = new Contact("Mary", 6163871111, 'F', false);

            p1.ShowContactData();
            p2.ShowContactData();
            p3.ShowContactData();
        }
    }
}

/*
Enter name:  Lucy
Enter phone (with area code like: 2693871000):  1234567890
Is he/she a Friend or Workmate?  Enter F or W:  W
Does he/she live in Kalamazoo?  Enter true or false:  true


name:Robert, phone:3456789, f/w:W, kzoo?:True

name:Lucy, phone:4567890, f/w:W, kzoo?:True

name:Mary, phone:6163871111, f/w:F, kzoo?:False

Press any key to continue . . .
*/