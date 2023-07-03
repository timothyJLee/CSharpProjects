using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assignment2LinkedListCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple Test of the Code:
            StreamReader inputFile;
            inputFile = File.OpenText("InputFile.txt");
                    Employee[] employeeArray = new Employee[int.Parse(inputFile.ReadLine().Trim())];
                    int arrayIndexerInt = 0;

                    while (!inputFile.EndOfStream)       // while NOT EOF
                    {                       // input first record
                        string[] separators = { ";" };
                        string value = inputFile.ReadLine();
                        string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        employeeArray[arrayIndexerInt] = new Employee(words[0], words[1], int.Parse(words[2]));
                        arrayIndexerInt++;
                    }


            List employeeList = new List("Employee List Test");

            Employee e1 = new Employee("Smith", "John",2354);

            for (int i = 0; i < employeeArray.Length; i++)
            {
                employeeList.InsertAtFront(employeeArray[i]);
            }

            employeeList.SortList();
            employeeList.Print();

            string inputFirstName;
            string inputLastName;
            int inputIDNumber;

            Console.WriteLine("Press any key to enter new employee.");
            Console.ReadLine();

            Console.Write("Enter First Name: ");
            inputFirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            inputLastName = Console.ReadLine();

            Console.Write("Enter ID number: ");
            int idNumber;
            while(!(int.TryParse(Console.ReadLine(), out idNumber)))
            {
                Console.WriteLine("Please enter an integer value for ID number.");
            }

            employeeArray[0] = new Employee(inputLastName, inputFirstName, idNumber);
            employeeList.InsertAtFront(employeeArray[0]);

            employeeList.SortList();
            employeeList.Print();

            Console.WriteLine("Press any key to exit...");

            Console.ReadLine();
        }
    }
}
