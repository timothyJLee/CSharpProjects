// Regular and Default Constructor
// This project involves a person's CONTACT data including their
//      name, phone, friendORwork, liveInKzoo
//      with 4 different data types:  string, long, char and bool.

// This example shows the use of 2 different constructors:
//      - a regular one, where the caller sends in 4 parameters
//      - the equivalent of the "default constructor", with 0 parameters
// ----------------------------------------------------------------------

using System;

namespace Contact2Constr
{
    public class Program
    {
        public static void Main()
        {
            Contact p1 = new Contact("Robert", 2693456789, 'W', true);
            Contact p2 = new Contact();                                 // calls default constructor; default values used
            Contact p3 = new Contact("Mary", 3871000, 'F', false);

            p1.ShowContactData();
            p2.ShowContactData();
            p3.ShowContactData();
        }
    }
}
