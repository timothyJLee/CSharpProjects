/* PROJECT: WorldDataAppCS (C#)         CLASS: RawData
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED: INPUT: RawData*.txt OUTPUT(indirect): BST.txt
 * FILE STRUCTURE:  field delimited traditional file structure CSV with sequential processing
 * DESCRIPTION:   Class for Handling the RawData*.txt file.  Provides methods for opening, closing
 *                outputting a record, finishing up.  Constructors and public get/setters.
 *******************************************************************************/

using System;
using System.IO;

namespace SharedClassLibrary
{
    public class RawData
    {
        //**************************** PRIVATE DECLARATIONS ************************        
        private static int count = 0;
        private string rawDataFileSuffix = "";
        private StreamReader rawDataStreamReader;

        private char[] code = new char[3];                           //Country code
        private char[] name = new char[17];                           //Name of country
        private char[] continent = new char[12];                      //What continent the country is located
        //private int surfaceArea;                      //Size of the country
        //private long population;                       //Total population of the country
        //private float lifeExpectancy;                  //The average time someone is alive in the country


        //**************************** PUBLIC GET/SET METHODS **********************
        public string RRN { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string SurfaceArea { get; set; }
        public string Population { get; set; }
        public string LifeExpectancy { get; set; }

        public static int Count { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public RawData(string rawDataSuffix)
        {
            Count = count = 0;
            rawDataFileSuffix = rawDataSuffix;
            rawDataStreamReader = new StreamReader("RawData" + rawDataSuffix + ".csv");
            count = NumOfRec();
            Count = count;
            rawDataStreamReader = new StreamReader("RawData" + rawDataSuffix + ".csv");
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Get one RawData Record to pass into SetupProgram
        /// </summary>
        public bool Input1Record()
        {
            string theLine = rawDataStreamReader.ReadLine();
            if (theLine != null)
            {
                string[] lineSplit = theLine.Split(',');
                RRN = lineSplit[0].Substring(30, 2);
                Code = lineSplit[1].Substring(1, lineSplit[1].Length - 1);
                Name = lineSplit[2].Substring(1, lineSplit[2].Length - 2);
                Continent = lineSplit[3].Substring(1, lineSplit[3].Length - 2);
                //Region = lineSplit[3].Substring(1, lineSplit[2].Length - 1);
                SurfaceArea = lineSplit[5];
                //YearOfIndep = lineSplit[5];
                Population = lineSplit[7];
                LifeExpectancy = lineSplit[8];
                count++;
                return true;
            }
            else
            {           // at end of RawDataFile
                Code = Name = Continent = SurfaceArea = Population = LifeExpectancy = "";
                FinishUp();
                return false;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Determine the number of records
        /// </summary>
        public int NumOfRec()
        {
            while (rawDataStreamReader.EndOfStream != true)
            {
                rawDataStreamReader.ReadLine();
                Count++;
            }
            rawDataStreamReader.Dispose();
            return Count;
        }


        //**************************** PRIVATE METHODS *****************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// FinishUp and close file
        /// </summary>
        private void FinishUp()
        {      // providing counts and closing files
            rawDataStreamReader.Close();
        }
    }
}
