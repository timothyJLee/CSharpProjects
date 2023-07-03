/* PROJECT: WorldDataAppCS (C#)         CLASS: TheLog
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:  OUTPUT: TheLog.txt
 * FILE STRUCTURE: Traditional/Sequential
 * DESCRIPTION: Interface Class for handling logFile.txt.  Provides methods for
 *       the input/output of logFile.txt for different classes under different circumstances.
 *       Contains the ability to create a logfile and write to it, as well as providing a finishup method
 *       to close it.
 *******************************************************************************/

using System;
using System.IO;

namespace SharedClassLibrary
{
    public class TheLog
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private StreamWriter logDataStreamWriter;  // for keeping log records within the TheLog Class itself


        //**************************** PUBLIC GET/SET METHODS **********************


        //**************************** PUBLIC CONSTRUCTOR(S) *********************** 
        public TheLog(String create)
        {
            logDataStreamWriter = new StreamWriter("TheLog.txt", false);
        }

        public TheLog()
        {
            logDataStreamWriter = new StreamWriter("TheLog.txt", true);
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Log record to log file
        /// </summary>
        public bool DisplayALogRec(string LogRec)
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
            logDataStreamWriter.WriteLine("FILE STATUS > TheLog FILE Closed");
            logDataStreamWriter.Close();
        }

        //**************************** PRIVATE METHODS *****************************
    }
}
