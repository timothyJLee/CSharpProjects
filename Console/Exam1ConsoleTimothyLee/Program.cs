using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam1ConsoleTimothyLee
{
    class Program
    {
        static void Main(string[] args)
        {

            //region for customer part of exam
            #region Customer
            Customer[] newCustomer = new Customer[3];
            newCustomer[0] = new Customer("Sally", 37482);
            newCustomer[1] = new Customer("John", 29385);
            newCustomer[2] = new Customer("Bianca", 92948);

            for(int i = 0; i < newCustomer.Length; i++)
            {
            Console.WriteLine(newCustomer[i]);
            }

            Console.WriteLine();
            #endregion     


            //region for pet part of exam
            #region Pet
            Pet[] myPet = new Pet[2];
            myPet[0] = new Dog("Spot", 11, 123);
            myPet[1] = new Pet("Spot");

            for (int i = 0; i < myPet.Length; i++)
            {
                Console.WriteLine(myPet[i]);
            }
            Console.WriteLine();
            #endregion


            //region for human part of exam
            #region Human
            Alice aliceHuman = new Alice("Alice", "Smith", 1999, 6.00, "January");
            Console.WriteLine(aliceHuman);
            Console.WriteLine();
            #endregion



            Console.ReadLine();
        }
    }
}
