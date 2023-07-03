//  auto-implemented properties  with an IF...
// CANNOT use Instance Var's here!


using System;

namespace ContactAutoImplProp
{
    class Program
    {
        static void Main()
        {
            Contact p1 = new Contact("Robert", 2693456789, 'W', true);
            Contact p2 = new Contact("Rajesh", 6164561212, 'X', true);
            Contact p3 = new Contact("Mary",   2693871000, 'f', false);

            p1.ShowContactData();
            p2.ShowContactData();
            p3.ShowContactData();

            Console.WriteLine("\n(Now back in Main) - Here's the data:\n");

            Console.WriteLine("{0,-10}{1,-18}{2,-12}  {3}",
                "NAME", "PHONE NUMBER", "FRIEND/WORK", "KALAMAZOO?");

            Console.WriteLine("{0,-10}{1:(###) ###-####    }{2,-12}  {3}",
                p1.Name,
                p1.Phone,
                p1.FriendORwork == 'F' ? "Friend" : "WorkMate",
                p1.LiveInKzoo ? "yes" : "no");

            Console.WriteLine("{0,-10}{1:(###) ###-####    }{2,-12}  {3}",
                p2.Name,
                p2.Phone,
                p2.FriendORwork == 'F' ? "Friend" : "WorkMate",
                p2.LiveInKzoo ? "yes" : "no");

            Console.WriteLine("{0,-10}{1:(###) ###-####    }{2,-12}  {3}",
                p3.Name,
                p3.Phone,
                p3.FriendORwork == 'F' ? "Friend" : "WorkMate",
                p3.LiveInKzoo ? "yes" : "no");
        }
    }
}


/*  OUTPUT
name:Robert, phone:2693456789, f/w:W, kzoo?:True

name:Rajesh, phone:6164561212, f/w:W, kzoo?:True

name:Mary, phone:2693871000, f/w:F, kzoo?:False


(Now back in Main) - Here's the data:

NAME      PHONE NUMBER      FRIEND/WORK   KALAMAZOO?
Robert    (269) 345-6789    WorkMate      yes
Rajesh    (616) 456-1212    WorkMate      yes
Mary      (269) 387-1000    Friend        no
Press any key to continue . . .
*/