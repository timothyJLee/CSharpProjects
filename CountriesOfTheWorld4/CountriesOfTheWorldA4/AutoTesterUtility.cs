/* PROJECT: WorldDataAppCS ASSN #4 (C#)         PROGRAM: AutoTesterUtility
 * AUTHOR: Timothy Lee / CS3310
 * Programs Used CLASSES USED (for Asgn 4):  UserApp, TheLog
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      OUTPUT:               
 * DESCRIPTION:  The program itself is the Tester which calls UserApp with the proper suffixes for files.
 * It also deletes any left over files from last run.
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      For Loop for multiple runs
 *      {  
 *      Calls programs with proper suffixes passed *      
 *      }
 *      finish up with LogFile
 *  *******************************************************************************/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupProgram;  // having to add in order to call the programs
using UserApp;
using SharedClassLibrary;

namespace CountriesOfTheWorldA4
{
    public class AutoTesterUtility
    {
        public static void Main(string[] args)
        {//Delete the SINGLE output Log.txt file (if it exists) and create new file
            TheLog logFileInterface = new TheLog("create");    //ONLY FOR DELETING LOG FILE!!!
            logFileInterface.FinishUp();
            string[] transFileSuffix = { "8", "8", "8" };

            for (int i = 1; i < 4; i++) // For statement to cycle through runs of programs
            {
                // Run All Coded Programs
                UserApp.UserApp.Main(new string[] { i.ToString() });
            }
        }


        //**************************************************************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Deletes files from last run
        /// </summary>
        private static bool DeleteFile(String fileName) // File Deleter
        {
            TheLog DeleteLog = new TheLog();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                DeleteLog.FinishUp();
                return true;
            }
            else
            {
                DeleteLog.FinishUp();
                return false;
            }
        }
    }
}

