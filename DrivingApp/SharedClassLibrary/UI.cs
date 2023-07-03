/* PROJECT: DrivingAppA5 (C#)         CLASS: UI
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:  INPUT: ?CityPairs.txt
 * FILE STRUCTURE: Traditional/Sequential
 * DESCRIPTION: Interface Class for handling CityPairs.txt.  Provides methods for
 *       the input/output of CityPairs.txt for different classes under different circumstances.
 *       Contains the ability to read a TransData and output it, as well as providing a finishup method
 *       to close it.
 *******************************************************************************/
/* PROJECT: DrivingAppA5 (C#)         CLASS: UI
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:  OUTPUT: TheLog.txt
 * FILE STRUCTURE: Traditional/Sequential
 * DESCRIPTION: Interface Class for handling logFile.txt.  Provides methods for
 *       the input/output of logFile.txt for different classes under different circumstances.
 *       Contains the ability to create a logfile and write to it, as well as providing a finishup method
 *       to close it.
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharedClassLibrary
{
    public class UI
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private StreamWriter logDataStreamWriter;  // for keeping log records within the TheLog Class itself
        private StreamReader cityPairsStreamReader;

        //?CityPairs.txt (includes <CR><LF>’s) [EuropeTrans and OtherTrans versions]
        //• Each line contains a pair of city NAMES: startCityName space destinationCityName
        //• cityNames area always single words (e.g., Grand Rapids would be GrandRapids)


        //**************************** PUBLIC GET/SET METHODS **********************


        //**************************** PUBLIC CONSTRUCTOR(S) *********************** 
        public UI(String create, string passedFilePreFixString)
        {
            logDataStreamWriter = new StreamWriter("TheLog.txt", false);
            cityPairsStreamReader = new StreamReader(passedFilePreFixString + "CityPairs.txt", true);
        }
        public UI(string passedFilePreFixString)
        {
            logDataStreamWriter = new StreamWriter("TheLog.txt", true);
            cityPairsStreamReader = new StreamReader(passedFilePreFixString + "CityPairs.txt", true);
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Log record to log file
        /// </summary>
        public bool WriteThis(string LogRec)
        {
            try
            {
                logDataStreamWriter.WriteLine(LogRec);
                return true;
            }
            catch (Exception e)
            {
                logDataStreamWriter.WriteLine(e);
                logDataStreamWriter.WriteLine("**ERROR: write to LogFile failed(Class:TheLog.cs");
                return false;
            }

        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Close log file
        /// </summary>
        public void FinishUp()
        {
            logDataStreamWriter.Close();
            cityPairsStreamReader.Close();
        }

        public bool MoreTrans(out string[] record)
        {
            string theLine = cityPairsStreamReader.ReadLine();
            record = null;
            if (theLine != "" && theLine != null)
            {
                string[] lineSplit = theLine.Split(' ');
                record = lineSplit;
                return true;
            }
            else
            {           // at end of RawDataFile
                FinishUp();
                return false;
            }
        }
        //public void WriteThis(string writeString)
        //{
            //# # # # # # # # # # # # # # # #
            //Amsterdam (0) TO Kalamazoo (-1)
            //ERROR – one of the cities is not on this map
            //# # # # # # # # # # # # # # # #
            //Kalamazoo (-1) TO Amsterdam (0)
            //ERROR – one of the cities is not on this map
            //# # # # # # # # # # # # # # # #
            //Paris (13) TO Copenhagen (6)
            //DISTANCE: 907
            //PATH: Paris > Brussels > Amsterdam > Hamburg > Copenhagen
            //TRACE OF TARGETS: Brussels Amsterdam Bern Genoa Hamburg Madrid Munich Rome
            //Berlin Trieste Copenhagen
            ////# TARGETS: 11
            //# # # # # # # # # # # # # # # #
            //Amsterdam (0) TO Bern (3)
            //DISTANCE: 558
            //PATH: Amsterdam > Bern
            //TRACE OF TARGETS: Brussels Hamburg Paris Munich Bern
            //# TARGETS: 5
            //# # # # # # # # # # # # # # # #
            //Warsaw (18) TO Warsaw (18)
            //DISTANCE: 0
            //PATH: Warsaw
            //TRACE OF TARGETS: Warsaw
            //# TARGETS: 0
            //# # # # # # # # # # # # # # # #
            //London (20) TO Dublin (19)
            //DISTANCE: ?
            //PATH: SORRY – can’t reach destination city from start city
            //TRACE OF TARGETS: . . . [show me what these are – let it happen as normal]
            //# TARGETS: . . . [show me what this is – let it happen as normal]
        //}

        //public void PrettyPrint()
        //{
            //Map Data: Europe Number of cities: 19
            //Amsterdam
            //. . .
            //Warsaw
            //   0 1 2 3 4 5 6 7 8 9 10 . . . 18
            //--------------------------------------------------------------------
            //0| 0 512 123 1321 312 432 567 1111 1122 211 1321 . . . 1104
            //1| 1133 0 444 449 512 1212 654 102 109 1001 1010 . . . 345
            //. . .
            //18| 123 234 345 456 567 678 789 890 111 222 333 . . . 0
        //}
    }
}
