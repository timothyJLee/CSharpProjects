/* PROJECT: DrivingAppA5 (C#)         CLASS: Map
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:
 *       INPUT: ?Roads.bin
 *       OUTPUT: ?CityNames.txt, TheLog.txt
 * FILE STRUCTURE:  Direct Address, Random Access, sequential
 * DESCRIPTION:  An OOP class with constructors, public getters/setters, private vars and methods, and public methods,
 *             for input of roads.bin and citynames.txt.  Contains the ability to open files
 *             Constructor, as well as the ability to read a record, write a record or close the data File.
 *             Reads individual edge weights(which correlate to road distances) from roads.bin which contains an 
 *             external adjacency matrix.  Is accessed from ShortestPath in implementing Dijkstra's Algorithm.
*******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharedClassLibrary
{
    public class Map
    {
        string filePreFixString;

        FileStream roadsFile;
        BinaryReader bRoadsFileReader;
        BinaryWriter bRoadsFileWriter;
        FileStream cityNamesFile;
        StreamReader cityNamesStreamReader;

        private static short privN;
        private static char graphType;
        private static string[] cityNames;

        private short _sizeOfHeaderRec = sizeof(char) + sizeof(short);
        private short _sizeOfARow;

        public static short N { get { return privN; } set { privN = value; } }
        public static char GraphType { get { return graphType; } set { graphType = value; } }
        public static string[] CityNames { get { return cityNames; } set { cityNames = value; } }  // Never actually used but good for testing

        public Map(string passedFilePreFixString)
        {
            filePreFixString = passedFilePreFixString;

            roadsFile = new FileStream((filePreFixString + "Roads.bin"), FileMode.Open);
            cityNamesFile = File.Open((filePreFixString + "CityNames.txt"), FileMode.Open, FileAccess.ReadWrite);
            bRoadsFileReader = new BinaryReader(roadsFile);
            bRoadsFileWriter = new BinaryWriter(roadsFile);
            cityNamesStreamReader = new StreamReader(cityNamesFile);

            graphType = bRoadsFileReader.ReadChar();
            privN = bRoadsFileReader.ReadInt16();

            _sizeOfARow = (short)(sizeof(short) * N);
            LoadCityNameArray();
        }


        public string WhatsCityName(short cityNumber)
        {
            //Direct Address on INTERNAL cityNames Array
            return cityNames[cityNumber];
        }

        public short WhatsCityNumber(string cityName)
        {
            //Linear Search of INTERNAL cityNames Array
            for (short i = 0; i < cityNames.Length; i++)
            {
                if (cityName == cityNames[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public short GetRoadDistance(short cityNum1, short cityNum2) // Edge Weight!!!
        {
            //Random Access using EXTERNAL Roads.bin
            if (graphType == 'U') // Checks both combinations of citypairs for undirected graphs
            {
                short returnShort;
                int offset = ((cityNum1 * _sizeOfARow) + (cityNum2 * sizeof(short)));

                if (offset < bRoadsFileReader.BaseStream.Length && offset > 0)
                {
                    bRoadsFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    bRoadsFileReader.ReadChar();
                    bRoadsFileReader.ReadInt16();
                    returnShort = bRoadsFileReader.ReadInt16();
                    if (returnShort == short.MaxValue)
                    {
                        offset = ((cityNum2 * _sizeOfARow) + (cityNum1 * sizeof(short)));
                        bRoadsFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);
                        bRoadsFileReader.ReadChar();
                        bRoadsFileReader.ReadInt16();
                        returnShort = bRoadsFileReader.ReadInt16();
                    }
                    return returnShort;
                }
                return -1;
            }
            else
            {  //  Checking for Directed Graphs
                int offset = ((cityNum1 * _sizeOfARow) + (cityNum2 * sizeof(short)));

                if (offset < bRoadsFileReader.BaseStream.Length && offset > 0)
                {
                    bRoadsFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    bRoadsFileReader.ReadChar();
                    bRoadsFileReader.ReadInt16();
                    return bRoadsFileReader.ReadInt16();
                }
                return -1;
            }
        }

        public void FinishUp()
        {
            cityNamesStreamReader.Close();
            roadsFile.Close();
            bRoadsFileWriter.Close();
            bRoadsFileReader.Close();
        }


        private void LoadCityNameArray()
        {
            cityNames = new string[N];

            int i = 0;
            while(!cityNamesStreamReader.EndOfStream)
            {
                cityNames[i] = cityNamesStreamReader.ReadLine();
                i++;
            }
        }
    }
}
