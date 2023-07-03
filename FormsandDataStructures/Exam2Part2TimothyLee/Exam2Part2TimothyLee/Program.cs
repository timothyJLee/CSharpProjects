using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Exam2Part2TimothyLee
{
    class Program
    {
        static void Main(string[] args)
        {
            ALF alien = new ALF("Alf", "Romulan Homeplanet", 42);
            Console.WriteLine(alien.ToString());

            Console.WriteLine();

            Pizza p1 = new Pizza(3.32, 4);
            Pizza p2 = new Pizza(3.35, 2);

            if (p1 == p2)
            {
                Console.WriteLine("Pizza 1 and 2 are equal.");
            }
            else
            {
                Console.WriteLine("Pizza 1 and 2 are NOT equal.");
            }

            Console.WriteLine();

            StreamReader inputFile;
            string lineString;
            string nameString;
            string idString;
            inputFile = File.OpenText("InputFile.txt");
            CartoonCharacter[] cartoonCharacterArray = new CartoonCharacter[int.Parse(inputFile.ReadLine().Trim())];
            int arrayIndexerInt = 0;

            while (!inputFile.EndOfStream)       // while NOT EOF
            {                       // input first record
                lineString = inputFile.ReadLine();

                var field1 = lineString.Split(';');
                nameString = field1[0].Trim();
                idString = field1[1].Trim();

                cartoonCharacterArray[arrayIndexerInt] = new CartoonCharacter(nameString, int.Parse(idString));

                arrayIndexerInt++;
            }
            inputFile.Close();
            for (int i = 0; i < cartoonCharacterArray.Length; i++)
            {
                Console.WriteLine(cartoonCharacterArray[i].ToString());
            }

            Console.WriteLine();


            // Does not print out throws an empty list exception.  you said code looks fine and turn it in...

            List combinedList = new List();

            List list1 = new List();
            list1.InsertAtFront(4);
            list1.InsertAtFront(3);
            list1.InsertAtFront(2);
            list1.InsertAtFront(1);

            List list2 = new List();
            list2.InsertAtFront(9);
            list2.InsertAtFront(8);
            list2.InsertAtFront(7);
            list2.InsertAtFront(6);

            list1 = List.ReverseListOrder(list1);
            list2 = List.ReverseListOrder(list2);

            list1.CombineTwoLists(list2);

            list1.Print();

            

            Console.ReadLine();
        }
    }
}
