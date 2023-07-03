




/*
 * Timothy Lee
 * Assignment100: HashTable
 * 4/20/13
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assignment100FINALTimothyLee
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader inputFile;
            inputFile = File.OpenText("InputFile.txt");   // change to InputFile2.txt for second inputfile

            int size = int.Parse(inputFile.ReadLine().Trim());
            CustomHashTable<int, object> hash = new CustomHashTable<int, object>(size);

            List<object> sortList = new List<object>();
            int arrayIndexerInt = 0;

            while (!inputFile.EndOfStream)       // while NOT EOF
            {                       // input first record
                object value = inputFile.ReadLine();
                sortList.Add(value);
                arrayIndexerInt++;
            }

            sortList.Sort();   

            int sizecheck = 0;
            while (sizecheck <= size - 1)
            {
                hash.Add(sizecheck, sortList.ElementAt(sizecheck));
                sizecheck++;
            }


            sizecheck = 0;
            while (sizecheck <= size)
            {
                Console.WriteLine(hash.Find(sizecheck));
                sizecheck++;
            }


            String[] arrayToIncrease = new String[10];
            String[] tempArray = arrayToIncrease;
            arrayToIncrease = new String[20];            
            for (int i = 0; i < tempArray.Length; i++)
            {
                arrayToIncrease[i] = tempArray[i];
            }
            arrayToIncrease[19] = "Doubled Size of Array!";
            foreach( String s in arrayToIncrease)
            {
                Console.WriteLine(s);
            }

            Console.Read();

        }
    }
}
