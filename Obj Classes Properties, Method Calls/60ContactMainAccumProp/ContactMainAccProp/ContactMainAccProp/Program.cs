// Main can access a public property of another class (but not anything private!)

using System;               // properties and FORMATTING 

namespace ContactMainAccProp
{
    class Program
    {
        static void Main()
        {
            Contact p1 = new Contact("Robert", 2693456789, 'W', true);          // send in 4 parms
            Contact p2 = new Contact("Rajesh", 6164561212, 'F', true);          // new Contact = constructor call
            Contact p3 = new Contact("Mary",   2693871000, 'F', false);         // same name as Class

            p1.ShowContactData();                       // AGAIN...PUBLIC OR PRIVATE METHOD???
            p2.ShowContactData();
            p3.ShowContactData();

            Console.WriteLine("\n(Now back in Main) - Here's the data:\n");

            // FORMATTING:   {0,  } {1,    } etc is to accept variable data... the 2nd value is used to show how
            //                              that value is to be placed...  -# means it's right justified
            //" {0,-10}"     for Name -   fit into 10 cols - right justified    (+ # is Left justified)
            // {{"1:(###) ###-####    "}  - gives fmt and spacing  

            Console.WriteLine("{0,-10}{1,-18}{2,-12}  {3}",              // constants put into place holder
                "NAME", "PHONE NUMBER", "FRIEND/WORK", "KALAMAZOO?");

            Console.WriteLine("{0,-10}{1:(###) ###-####    }{2,-12}  {3}",           //  COMMA SEPARATED
                p1.Name,                                     // using PROPERTY Name  (can't use instance vars)
                p1.Phone,                                    // object . Property 
                p1.FriendORwork == 'F' ? "Friend" : "WorkMate",     // condition (called 'ternary'???)
                p1.LiveInKzoo ? "yes" : "no");

            Console.WriteLine("{0,-10}{1:(###) ###-####    }{2,-12}  {3}",          // do for each
                p2.Name,                                                    // better way? of course
                p2.Phone,                                   // put in loop and call in loop - LATER!
                p2.FriendORwork == 'F' ? "Friend" : "WorkMate",         // condition for what's O
                p2.LiveInKzoo ? "yes" : "no");                      // condition b/c Boolean!

            Console.WriteLine("{0,-10}{1:(###) ###-####    }{2,-12}  {3}",
                p3.Name,
                p3.Phone,
                p3.FriendORwork == 'F' ? "Friend" : "WorkMate",
                p3.LiveInKzoo ? "yes" : "no");

            Console.WriteLine("\n\n(Still in Main)");

            const int div = 10000000;

            //can use Public Properties inside of Main.
            //   when div by lg # (div) - grabs quotient (# digits to get rid of)
          //  with   % - # digits want to keep
  
            if (p1.Phone / div == p3.Phone / div)
                Console.WriteLine("{0} and {1} both have same area code, {2}\n",
                    p2.Name, p3.Name, p1.Phone / div);

            long sum = p1.Phone + p2.Phone + p3.Phone;
            Console.WriteLine("The sum of the 3 phone numbers is {0:N0}\n", sum);
        }
    }
}
/*  OUTPUT:
 * 
name:Robert, phone:2693456789, f/w:W, kzoo?:True

name:Rajesh, phone:6164561212, f/w:F, kzoo?:True

name:Mary, phone:2693871000, f/w:F, kzoo?:False


(Now back in Main) - Here's the data:

NAME      PHONE NUMBER      FRIEND/WORK   KALAMAZOO?
Robert    (269) 345-6789    WorkMate      yes
Rajesh    (616) 456-1212    Friend        yes
Mary      (269) 387-1000    Friend        no


(Still in Main)
Rajesh and Mary both have same area code, 269

The sum of the 3 phone numbers is 11,551,889,001

Press any key to continue . . .

*/