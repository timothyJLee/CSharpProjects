using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assignment11
{
    class Program
    {
        //menu vars
        public static Menu menu;
        delegate void GeneralDelegate();

        public static List customersList = new List("TEAM_ONE_LIST");

        static void Main(string[] args)
        {
            //initialize menu
            menu = new Menu("Team 1 Program");
            GeneralDelegate gd;

            gd = loadData;
            menu.addOption("Load Data", gd);

            gd = addCustomer;
            menu.addOption("Add Customer", gd);

            gd = displayCustomers;
            menu.addOption("Sort by Age and Display Customers", gd);

            gd = exit;
            menu.addOption("Exit", gd);

            menu.run();
        }

        private static void exit()
        {
            Environment.Exit(0);
        }

        //loads data in steph's semi-colon delimitted format and pushes line data to lineDataToObject
        public static void loadData()
        {
            Console.WriteLine("Reading from 'data.txt'...");
            string filepath = "data.txt";

            try
            {
                StreamReader file = new StreamReader(filepath);

                string line;
                int dummy;
                string[] lineData;

                Console.WriteLine("Loading...");
                while (file.Peek() != -1)
                {
                    line = file.ReadLine().Trim();

                    //if entire line is a number, presume its the top of the file line count and skip it
                    if (Int32.TryParse(line, out dummy))
                        continue;

                    lineData = line.Split(';');
                    lineDataToObject(lineData);
                    Console.WriteLine("   " + line);
                }
                Console.WriteLine("File loaded.");
            }
            catch
            {
                Console.WriteLine("Invalid filepath.");
            }
        }

        //creates an object from a line out of input file
        public static void lineDataToObject(string[] data)
        {
            addCustomer(data[0], Int32.Parse(data[1]), data[2]);
        }

        public static void addCustomer()
        {
            Console.WriteLine("Please enter employee information.");

            Console.Write("   Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("   Age: ");
            int age;
            if (!Int32.TryParse(Console.ReadLine().Trim(), out age))
            {
                Console.WriteLine("Error: Age must be an integer.");
                return;
            }

            Console.Write("   Status: ");
            string status = Console.ReadLine().Trim();
            if (status != "member" && status != "visitor")
            {
                Console.WriteLine("Error: Status must be 'member' or 'visitor'.");
                return;
            }

            addCustomer(name, age, status);

            Console.WriteLine("Customer added.");
        }

        public static void addCustomer(string name, int age, string status)
        {
            if (status == "member")
                customersList.Insert(new Member(status, name, age));
            else if (status == "visitor")
                customersList.Insert(new NonMember(status, name, age));
        }

        public static void displayCustomers()
        {
            customersList.Print();
        }
    }
}
