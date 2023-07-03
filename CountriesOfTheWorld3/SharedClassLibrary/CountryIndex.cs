using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace SharedClassLibrary
{
    public class CountryIndex
    {
        private static FileStream CountryIndexFile;
        private static FileStream CountryIndexBackUpFile;
        private StreamReader countryIndexStreamReader;
        private StreamWriter countryIndexStreamWriter;

        private static BSTData[] DataArray;

        private static short MAX_N_HOME_LOC = 20;
        private static short nColl; //Number of collisions.
        private static short nHome; //Number of records.
        private static short nRec;

        private static short drp;
        private static short nextEmpty;


        public static BSTData[] PDataArray { get { return DataArray; } set { DataArray = value; } }


        //------------------------------------------------------------------------------
        /// <summary>
        /// constructor for creating files
        /// </summary>
        public CountryIndex(string createString)
        {
            CountryIndexBackUpFile = new FileStream("CountryIndexBackUp.csv", FileMode.Create);
            CountryIndexFile = new FileStream("CountryIndex.csv", FileMode.Open);
            countryIndexStreamReader = new StreamReader(CountryIndexFile);
            countryIndexStreamWriter = new StreamWriter(CountryIndexBackUpFile);
            DataArray = new BSTData[MAX_N_HOME_LOC + 20];
            nextEmpty = 19;
            nColl = 0;
            nHome = 0;
            nRec = 0;
        }
        //------------------------------------------------------------------------------
        /// <summary>
        /// constructor for opening files
        /// </summary>
        public CountryIndex()
        {
            CountryIndexBackUpFile = new FileStream("CountryIndexBackUp.csv", FileMode.Open);
            CountryIndexFile = new FileStream("CountryIndex.csv", FileMode.Open);
            countryIndexStreamReader = new StreamReader(CountryIndexFile);
            countryIndexStreamWriter = new StreamWriter(CountryIndexBackUpFile);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// saving table to backup
        /// </summary>
        public void SaveTable()
        {
            for (int i = 0; i < DataArray.Length; i++)
            {
                if (DataArray[i] != null)
                {
                    countryIndexStreamWriter.WriteLine(new string(DataArray[i].Code) + ',' + DataArray[i].IndexDRP + ',' + DataArray[i].IndexLink);
                }
                else
                {
                    countryIndexStreamWriter.WriteLine(',' + ',' + -1);
                }
            }
        }
        //------------------------------------------------------------------------------
        /// <summary>
        /// Restoring table to array
        /// </summary>
        public void RestoreTable()
        {
            while (Input1Record())
            {

            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// closing files and readers
        /// </summary>
        public void SnapShotUtility(TheLog snapLog, bool printTable)
        {
            PrintResults(snapLog, CountryIndex.PDataArray);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Formates the header to be displayed
        /// </summary>
        /// <returns>A ready to use string aligned in its columns</returns>
        private static string FormatHeader(string indexHeader)
        {
            return "[SUB]".PadRight(6) +
                   "CODE".PadRight(6) +
                   "DPR".PadRight(6) +
                   "LINK".PadRight(6);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Print the results from the formatted text
        /// </summary>
        private void PrintResults(TheLog printLog, BSTData[] IndexDataList)
        {
            int nRec = IndexDataList.Length;

            string header = FormatHeader("Index");

            printLog.DisplayALogRec("");
            printLog.DisplayALogRec("\n***************SNAPSHOT UTILITY STARTED***************\n");
            printLog.DisplayALogRec("COUNTRY DATA FILE".PadRight(header.Length + 1, '*'));
            printLog.DisplayALogRec(header);

            int i = 0;
            foreach (BSTData s in IndexDataList)
            {
                if (s != null)
                {
                    if (new string(s.Code) == "\0\0\0" | new string(s.Code) == "   ") //finish handling all variations of emtpy rec
                    {
                        printLog.DisplayALogRec("[" + s.IndexSubScript.ToString().PadLeft(3, '0') + "]".PadRight(2) + " EMPTY");
                    }
                    else
                    {
                        printLog.DisplayALogRec("[" + s.IndexSubScript.ToString().PadLeft(3, '0') + "]".PadRight(2) + new string(s.Code).PadRight(6) +
                                       s.IndexDRP.ToString().PadLeft(3, '0').PadRight(6) + s.IndexLink.ToString("D3").PadLeft(3));
                    }
                }
                else
                {
                    printLog.DisplayALogRec(("[" + i.ToString().PadLeft(3, '0') + "]".PadRight(2) + " EMPTY"));
                }
                i++;
            }

            printLog.DisplayALogRec("End".PadRight(header.Length + 1, '*'));
            printLog.DisplayALogRec("");

            printLog.DisplayALogRec("#Rec in COUNTRY TABLE FILE: " + (++nHome + nColl) + " #HomeRec: " + nHome + " #CollRec: " + nColl);
            printLog.DisplayALogRec("\n**********End Of SNAPSHOT UTILITY**********\n");
            printLog.DisplayALogRec("");
            printLog.DisplayALogRec("");
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// public service method for Selecting by Code
        /// </summary>
        public bool SelectByCode(out BSTData aRec, char[] code)
        {
            short DRP = HashFunction(code);
            if (HashSearch(DRP, code, out aRec))
            {
                return true;
            }
            else
            {
                aRec = null;
                return false;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Public Service Method for Inserting into Index
        /// </summary>
        public bool InsertCodeInIndex(BSTData aRec, char[] code)
        {
            return false;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Method for Inputting a Record(NOT DONE SEQUENTIALLY, DONE AS AN ACTUAL HASH)
        /// </summary>
        public bool Input1Record()
        {
            BSTData hashRecord;
            string arrayChooser;
            string theLine = countryIndexStreamReader.ReadLine();
            if (theLine != "" && theLine != null)
            {
                string[] lineSplit = theLine.Split(',');
                if (lineSplit[0].Length == 3)
                {
                    BSTData newRec = new BSTData(lineSplit[0].ToCharArray(), (short)int.Parse(lineSplit[2]), (short)int.Parse(lineSplit[1]));
                    newRec.IndexHomeSubScript = HashFunction(newRec.Code);
                    if (HashSearch(newRec, newRec.IndexHomeSubScript, out arrayChooser, out hashRecord))
                    {
                        if (arrayChooser == "Home")
                        {
                            newRec.Location = new char[1];
                            newRec.Location[0] = 'H';
                            newRec.Link = -1;
                            DataArray[newRec.IndexHomeSubScript] = newRec;
                            nHome++;
                            nRec++;
                        }
                        else
                        {
                            nextEmpty++;
                            newRec.Location = new char[1];
                            newRec.Location[0] = 'C';
                            newRec.Link = DataArray[newRec.IndexHomeSubScript].Link;
                            newRec.IndexSubScript = nextEmpty;
                            DataArray[nextEmpty] = newRec;
                            DataArray[newRec.IndexSubScript].Link = newRec.IndexSubScript;
                            nColl++;
                            nRec++;
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Reading a record to see if its in array
        /// </summary>
        public bool Read1Record(out BSTData aRec, int DRP)
        {
            if (DRP != -1 && DataArray[DRP] != null)
            {
                aRec = DataArray[DRP];
                return true;
            }
            else
            {
                aRec = null;
                return false;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Hash Search for finding record in INdex
        /// </summary>
        private bool HashSearch(short hashDRP, char[] hashCode, out BSTData hashRec)
        {
            if (Read1Record(out hashRec, hashDRP))
            {
                if (hashRec != null)
                {
                    if (new string(hashCode).CompareTo(new string(hashRec.Code)) == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    hashRec.Link = hashDRP;

                    while (Read1Record(out hashRec, hashRec.Link) && hashRec != null)
                    {
                        if (new string(hashCode).CompareTo(new string(hashRec.Code)) == 0)
                        {
                            return true;
                        }
                        hashDRP = hashRec.Link;
                    }
                    return false;
                }
            }

            hashRec = null;
            return false;
        }
        //------------------------------------------------------------------------------
        /// <summary>
        /// overloaded method for finding location in index
        /// </summary>
        private bool HashSearch(BSTData hashSearchRecord, short searchDRP, out string arrayChooser, out BSTData hashRecord)
        {
            List<BSTData> RecordCollection = new List<BSTData>(); //List of formatted record strings
            if (Read1Record(out hashRecord, searchDRP))
            {
                arrayChooser = "";

                if (hashRecord == null)
                {
                    arrayChooser = "Home";
                }
                else
                {
                    arrayChooser = "Coll";
                    searchDRP = hashRecord.Link;

                    while (Read1Record(out hashRecord, searchDRP) && hashRecord != null)
                    {
                        RecordCollection.Add(hashRecord);
                        if (new string(hashSearchRecord.Code).CompareTo(new string(hashRecord.Code)) == 0)
                        {
                            return true;
                        }
                        searchDRP = hashRecord.Link;
                    }
                    return true;
                }
            }
            arrayChooser = "Home";
            return true;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// method for calculating RRN from Code
        /// </summary>
        private short HashFunction(char[] hashCode)
        {
            int homeRRN;
            int multASCIICodes;
            int[] convertedASCII;

            foreach (char c in hashCode)
            {
                c.ToString().ToUpper().ToCharArray();
            }

            convertedASCII = CharToASCIIConversion(hashCode);

            multASCIICodes = convertedASCII[0] * convertedASCII[1] * convertedASCII[2];
            homeRRN = (multASCIICodes % MAX_N_HOME_LOC);

            return (short)homeRRN;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Method for converting chars into their ASCII short counterparts
        /// </summary>
        private int[] CharToASCIIConversion(char[] charArray)
        {
            int[] convertedArray = new int[charArray.Length];

            char[] ASCIILookUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int i = 0;
            for (int j = 0; j < charArray.Length; j++)
            {
                i = 0;
                while (charArray[j] != ASCIILookUp[i])
                {
                    i++;
                }
                convertedArray[j] = (65 + i);
            }
            return convertedArray;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// closing files and readers
        /// </summary>
        public void FinishUp(TheLog finishUpLog, bool printBool)
        {
            SaveTable();
            CountryIndexFile.Close();
            countryIndexStreamReader.Close();
            countryIndexStreamWriter.Close();
            SnapShotUtility(finishUpLog, printBool);
        }
    }
}
