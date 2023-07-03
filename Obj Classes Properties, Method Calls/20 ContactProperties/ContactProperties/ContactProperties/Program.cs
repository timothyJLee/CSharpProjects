// Property for every instance Variable

using System;

namespace ContactProperties
{
    class Program
    {
        static void Main()
        {
            Contact person1 = new Contact("Robert", 2693456789, 'W', true);

            Contact person2 = new Contact();             // uses empty constructor; data acquired from Contact class method
            person2.GetDataFromUser();                   // uses GetDataFromUser method to populate data  PUBLIC OR PRIVATE METHOD??

            Contact person3 = new Contact("Mary", 3871111, 'F', false);

            person1.ShowContactData();          // TO CALL A METHOD FROM 'MAIN' ..ARE METHODS PUBLIC OR PRIVATE??
            person2.ShowContactData();
            person3.ShowContactData();

            //   TO ACCESS DATA FROM THE BUSINESS TIER MUST USE INSTANCE.PROPERTY 
            //Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
            //    person1.Name, person1.Phone, person1.FriendORwork, person1.LiveInKzoo);         // PROPERTY NAMES MUST BE USED HERE!

            //Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
            //   person2.Name, person2.Phone, person2.FriendORwork, person2.LiveInKzoo);         // PROPERTY NAMES MUST BE USED HERE!

            //Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
            //   person3.Name, person3.Phone, person3.FriendORwork, person3.LiveInKzoo);         // PROPERTY NAMES MUST BE USED HERE!

        }
    }
}


/*
 Enter name:  Fred
Enter phone (with area code like: 2693871000):  9877890098770
Is he/she a Friend or Workmate?  Enter F or W:  w
Does he/she live in Kalamazoo?  Enter true or false:  true


name:Robert, phone:2693456789, f/w:W, kzoo?:True

name:Fred, phone:9877890098770, f/w:w, kzoo?:True

name:Mary, phone:3871111, f/w:F, kzoo?:False

Press any key to continue . . .
 * */
