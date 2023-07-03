/* PROJECT: CountriesOfTheWorldA2 (C#)         CLASS: TransData
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:  INPUT: TransData.txt
 * FILE STRUCTURE: Traditional/Sequential
 * DESCRIPTION: Interface Class for handling TransData.txt.  Provides methods for
 *       the input/output of TransData.txt for different classes under different circumstances.
 *       Contains the ability to read a TransData and output it, as well as providing a finishup method
 *       to close it.
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedClassLibrary;

namespace UserApp
{
    class TransData
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private string transactionInputString;
        private int iD;
        private char[] transCode;
        private int transCount = 0;

        private StreamReader transactionDataStreamReader;


        //**************************** PUBLIC GET/SET METHODS **********************
        public string Id { get; set; }
        public string TransactionInput { get; set; }
        public char[] TransactionCode { get; set; }
        public string TransDataFileSuffix { get; set; }
        public string TransactionCount { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public TransData(string transDataSuffix) // public constructor for transData with suffix
        {
            transCount = 0;
            TransDataFileSuffix = transDataSuffix;
            transactionDataStreamReader = new StreamReader("TransData" + transDataSuffix + ".txt");
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Input a transrecord to userapp
        /// </summary>
        public bool InputATransRec(out string[] aTransRec, TheLog transRecLogFile)
        {
            string theLine = transactionDataStreamReader.ReadLine();

            if (theLine != null)
            {
                string[] lineSplit = theLine.Split(',');
                transactionInputString = lineSplit[0].Substring(0, 2);

                aTransRec = lineSplit;
                TransactionInput = transactionInputString;
                if (aTransRec[0].Length > 2)
                {

                    if (lineSplit[0].Substring(0, 2) != "IN") { transRecLogFile.DisplayALogRec(lineSplit[0]); }

                    if (aTransRec[0].Length > 5)
                    {
                        if (int.TryParse((aTransRec[0].Trim().Substring(3, 3)), out iD))
                        {

                        }
                        else
                        {
                            transCode = aTransRec[0].Trim().Substring(3, 3).ToCharArray(); // for longer queries
                        }
                    }
                    else
                    {
                        if (aTransRec[0].Length > 4)
                        {
                            int.TryParse((aTransRec[0].Trim().Substring(3, 2)), out iD);
                        }
                        else
                        {
                            int.TryParse((aTransRec[0].Trim().Substring(3, 1)), out iD); // for abnormally small queries
                        }
                    }
                    Id = iD.ToString();
                    TransactionCode = transCode;
                }

                transCount++;
                return true;
            }
            else // no transRec
            {
                aTransRec = null;
                Id = TransactionInput = string.Empty;

                FinishUp(transRecLogFile); // read all trans recs so finish up
                return false;
            }
        }


        //**************************** PRIVATE METHODS *****************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Finishup userapp and close file
        /// </summary>
        private void FinishUp(TheLog finishUpTransLog) // finish up method to take care of TranData*.txt
        {
            transactionDataStreamReader.Close();
            finishUpTransLog.DisplayALogRec("FILE STATUS > TransData FILE closed");
        }
    }
}
