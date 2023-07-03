///* PROJECT: WorldDataAppCS (C#)         PROGRAM: SnapShotUtility
// * AUTHOR: Timothy Lee / CS3310
// * NOTE***:  This code is adapted code from a free pretty print utility handed out to last semester's 3310 class by Kaminski.
// * Programs Used CLASSES USED (for Asgn 1):  SnapShotUtility, TheLog, CountryDataTable
// * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
// *      OUTPUT:  TheLog.txt, CountryDataTable.bin               
// * DESCRIPTION:  The program itself is the Tester which calls all the programs in order in order to create and display a Country Data File of
// *      processed rawdata.  It also deletes any left over files from last run.
// * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
// *      For Loop for multiple runs
// *      {  
// *      Calls programs with proper suffixes passed *      
// *      }
// *      finish up with LogFile
// *  *******************************************************************************/

//using System;
//using System.IO;
//using System.Text;
//using System.Collections.Generic;
//using SharedClassLibrary;


//namespace SnapShotUtility
//{
//    public class SnapShotUtility
//    {
//        static FileStream fMainDataFile;
//        static BinaryReader bMainDataFileReader;
//        private static int _sizeOfHeaderRec = sizeof(short);
//        private static int _sizeOfPhysicalDataRec = 3 * sizeof(char) + 16 * sizeof(char) + 13 * sizeof(char) + sizeof(int) + sizeof(long) + sizeof(float);

//        static short nRec; //Number of records.


//        public static void Main(string[] args)
//        {
//            TheLog snapLog = new TheLog();

//            fMainDataFile = new FileStream("CountryDataTable.bin", FileMode.Open);
//            bMainDataFileReader = new BinaryReader(fMainDataFile);
//            snapLog.DisplayALogRec("FILE STATUS > CountryData FILE opened");
//            nRec = bMainDataFileReader.ReadInt16();

//            string[] MainRecordList = ReadFile(bMainDataFileReader, _sizeOfHeaderRec);
//            PrintResults(MainRecordList, snapLog);
//            FinishUp();
//            snapLog.DisplayALogRec("FILE STATUS > CountryData FILE closed");
//            snapLog.FinishUp();
//        }

//        //---------------------------------------------------------------------------------------------
//        /// <summary>
//        /// Loop through and store all viable records into a array
//        /// </summary>
//        /// <param name="fileReader">Current binary reader for the file being accessed</param>
//        /// <param name="headerLength">Length (in bytes) of the header file</param>
//        /// <returns>An array of formatted records ready to be displayed</returns>
//        private static string[] ReadFile(BinaryReader fileReader, int headerLength)
//        {
//            char[] code;                           //Country code
//            char[] name;                           //Name of country
//            char[] continent;                      //What continent the country is located
//            int surfaceArea;                      //Size of the country
//            long population;                       //Total population of the country
//            float lifeExpectancy;                  //The average time someone is alive in the country
//            int RRN = 1;
//            string formatRecord;
//            List<string> RecordCollection = new List<string>(); //List of formatted record strings

//            for (long pos = headerLength; pos < fileReader.BaseStream.Length; pos += _sizeOfPhysicalDataRec, RRN++)
//            {
//                fileReader.BaseStream.Seek(pos, SeekOrigin.Begin);

//                code = fileReader.ReadChars(3);

//                if (code[0] == '\0')
//                {
//                    formatRecord = "[" + Convert.ToString(RRN).PadLeft(3, '0') + "]".PadRight(2) + "Empty";
//                }
//                else
//                {
//                    fileReader.ReadChars(1);
//                    name = fileReader.ReadChars(16);
//                    continent = fileReader.ReadChars(13);
//                    surfaceArea = fileReader.ReadInt32();
//                    population = fileReader.ReadInt64();
//                    lifeExpectancy = fileReader.ReadSingle();


//                    formatRecord = "[" + Convert.ToString(RRN).PadLeft(3, '0') + "]".PadRight(2) +
//                                    new string(code).PadRight(6) +
//                                    new string(name).PadRight(18) +
//                                    new string(continent).PadRight(12) +
//                                    string.Format("{0:#,###,###.##}", surfaceArea).PadLeft(10) +
//                                    string.Format("{0:#,###,###,###}", population).PadLeft(13).PadRight(12) +
//                                    string.Format("{0:0.#}", lifeExpectancy).PadRight(1).PadLeft(5);
//                }

//                RecordCollection.Add(formatRecord);
//            }

//            return RecordCollection.ToArray();

//        }


//        //-----------------------------------------------------------------------------
//        /// <summary>
//        /// Close all files that are open
//        /// </summary>
//        private static void FinishUp()
//        {
//            bMainDataFileReader.Close();
//            fMainDataFile.Close();
//        }



//        //------------------------------------------------------------------------------
//        /// <summary>
//        /// Formates the header to be displayed
//        /// </summary>
//        /// <returns>A ready to use string aligned in its columns</returns>
//        private static string FormatHeader()
//        {

//            return "[RRN]".PadRight(6) +
//                   "CODE".PadRight(6) +
//                   "NAME".PadRight(18, '-') +
//                   "CONTINENT".PadRight(12, '-') +
//                   "AREA".PadLeft(7, '-').PadRight(12, '-') +
//                   "POPULATION".PadLeft(12, '-').PadRight(13, '-') +
//                   "L.EX".PadRight(6).PadLeft(6);
//        }

//        //------------------------------------------------------------------------------
//        /// <summary>
//        /// Print the results from the formatted text
//        /// </summary>
//        private static void PrintResults(string[] MainDataList, TheLog logFile)
//        {
//            string header = FormatHeader();

//            logFile.DisplayALogRec("");
//            logFile.DisplayALogRec("\n***************SNAPSHOT UTILITY STARTED***************\n");
//            logFile.DisplayALogRec("COUNTRY DATA FILE".PadRight(header.Length + 1, '*'));
//            logFile.DisplayALogRec(header);

//            foreach (string s in MainDataList)
//            {
//                if (s != "")
//                {
//                    if (s.Substring(6, CountryDataTable.SizeOfRRN) == "\0\0\0" | s.Substring(6, CountryDataTable.SizeOfRRN) == "   ") //finish handling all variations of emtpy rec
//                    {
//                        logFile.DisplayALogRec((s.Substring(0, CountryDataTable.SizeOfRRN + 2) + " EMPTY"));
//                    }
//                    else
//                    {
//                        logFile.DisplayALogRec(s);
//                    }                    
//                }
//                else
//                {
//                    logFile.DisplayALogRec((s.Substring(0, CountryDataTable.SizeOfRRN + 2) + " EMPTY"));
//                }
//            }

//            logFile.DisplayALogRec("End".PadRight(header.Length + 1, '*'));
//            logFile.DisplayALogRec("");

//            logFile.DisplayALogRec("#Rec in COUNTRY TABLE FILE: " + nRec);
//            logFile.DisplayALogRec("\n**********End Of SNAPSHOT UTILITY**********\n");
//            logFile.DisplayALogRec("");
//            logFile.DisplayALogRec("");
//        }
//    }
//}
