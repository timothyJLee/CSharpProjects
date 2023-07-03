using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assignment11
{
    interface IMenu
    {
        void addOption(string text, Delegate callback);
        void runOption(int option);
        void printMenu();
    }

    class Menu : IMenu
    {
        private const string TAB = "   ";

        private List<string> _options = new List<string>();
        private List<Delegate> _callbacks = new List<Delegate>();

        private string _title = "Menu";

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Menu()
        {

        }

        public Menu(string title)
        {
            _title = title;
        }

        public void addOption(String text, Delegate callback)
        {
            _options.Add(text);
            _callbacks.Add(callback);
        }

        public void runOption(int option)
        {
            ((Delegate)_callbacks[option - 1]).Method.Invoke(this, new object[0]);
            Console.WriteLine();
        }

        public void printMenu()
        {
            Console.WriteLine(_title);

            for (int i = 0; i < _options.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + _options[i]);
            }

            Console.Write("> ");
        }

        public string prompt()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            Console.WriteLine();

            return input;
        }

        public void run()
        {
            while (true)
            {
                printMenu();

                string input = Console.ReadLine();
                Console.WriteLine();

                int choice;

                if (Int32.TryParse(input, out choice) && choice >= 1 && choice <= _options.Count)
                {
                    runOption(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input (non-integer or invalid menu choice).");
                    Console.WriteLine();
                }
            }
        }

        //DOESN'T WORK - NEEDS TLC
        //loads data in steph's semi-colon delimitted format and pushes line data to lineDataToObject
        public void loadData(Delegate callback)
        {
            Console.WriteLine("Enter the name of the file (i.e. \"data.txt\")");
            Console.WriteLine("Filepath may be local to the build path or global.");
            string filepath = prompt().Trim();

            //defaults blank filepath to "data.txt"
            if (filepath.Length == 0)
                filepath = "data.txt";

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
                    Console.WriteLine(TAB + line);
                }
                Console.WriteLine("File loaded.");
            }
            catch
            {
                Console.WriteLine("Invalid filepath.");
            }
        }

        //EXAMPLE CALLBACK FOR loadData
        //creates an object from a line out of input file
        public static void lineDataToObject(string[] data)
        {
            //Item item;

            //item = new Item(lineData[0], Int32.Parse(lineData[1]), Double.Parse(lineData[2]));
            //item.calculateTotal();
            //items.Add(item);
        }
    }
}
