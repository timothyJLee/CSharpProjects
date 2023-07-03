/* PROJECT: WorldDataAppCS (C#)         CLASS: CountryDataTable
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:
 *       INPUT: CountryDataTable.bin
 *       OUTPUT: CountryDataTable.bin, TheLog.txt
 * FILE STRUCTURE:  Direct Address, Random Access
 * DESCRIPTION:  An OOP class with constructors, public getters/setters, private vars and methods, and public methods,
 *             for input of data records and reading data records from a CountryDataTable.bin file. Uses a hash file 
 *             structure with fixed length fields and records.  Contains the ability to create or open CountryDataTable.bin in
 *             Constructor, as well as the ability to read a record, write a record or close the data File.
*******************************************************************************/

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections;



namespace SharedClassLibrary
{
    public class CountryDataTable
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private static short MAX_N_LOC = 30;

        private static FileStream fCountryDataTableFile;
        private static BinaryReader bCountryDataTableFileReader; //declaring binary I/Os
        private static BinaryWriter bCountryDataTableFileWriter;
        private static int _sizeOfHeaderRec = sizeof(short);  // declaring sizes of memory structures for seeking in file
        private static int _sizeOfLogicalDataRec = sizeof(short) + 3 * sizeof(char) + 16 * sizeof(char) + 13 * sizeof(char) + sizeof(int) + sizeof(long) + sizeof(float);
        static int _sizeOfPhysicalDataRec = _sizeOfLogicalDataRec + sizeof(short) * 3 + sizeof(char) * 3;


        private BSTData readNode;
        private BSTData writeNode;
        private BSTData currentNode;
        private BSTData hashNode;
        private BSTData returnNode;

        public static BSTData publicNode { get; set; }

        private string formatRecord;

        //  Setting the sizes of the fixed length records first in main data
        private static int sizeOfRRN = 2;
        private static int sizeOfCode = 3;
        private static int sizeOfName = 16;
        private static int sizeOfContinent = 13;
        private static int sizeOfSurfaceArea = 9; //sizeof(int);
        private static int sizeOfPopulation = 10; // sizeof(long);
        private static int sizeOfLifeExpectancy = 4; //sizeof(float);
        private static int sizeOfLink = 2; // sizeof(short);


        ////  For keeping count of total records
        private static short nRec;
        private static short nCollRec; //Number of collisions.
        private static short nHomeRec; //Number of records.


        //**************************** PUBLIC GET/SET METHODS **********************
        public static int SizeOfRRN { get; set; }
        public static int SizeOfCode { get; set; }
        public static int SizeOfName { get; set; }
        public static int SizeOfContinent { get; set; }
        public static int SizeOfSurfaceArea { get; set; }
        public static int SizeOfPopulation { get; set; }
        public static int SizeOfLifeExpectancy { get; set; }
        public static int SizeOfLink { get; set; }

        public static short NRec { get; set; }
        public static short NHome { get; set; }
        public static short NColl { get; set; }
        public static short MAXNUMLOC { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public CountryDataTable(int maxInt) // Constructor for Creating a CountryDataTable.bin File
        {
            ResetPrivatePublicValues();
            try
            {
                fCountryDataTableFile = new FileStream("CountryDataTable.bin", FileMode.Create);
                bCountryDataTableFileReader = new BinaryReader(fCountryDataTableFile);
                bCountryDataTableFileWriter = new BinaryWriter(fCountryDataTableFile);
                SetSize();
                NRec = 0; // Set count variables upon creation of CountryDataTable.bin
                NHome = 0;
                NColl = 0;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }

        }

        public CountryDataTable() //  Constructor for Opening a CountryDataTable.bin File
        {
            try
            {
                ResetPrivatePublicValues();

                fCountryDataTableFile = new FileStream("CountryDataTable.bin", FileMode.Open);
                bCountryDataTableFileReader = new BinaryReader(fCountryDataTableFile);
                bCountryDataTableFileWriter = new BinaryWriter(fCountryDataTableFile);

                ReadHeaderRecord();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Deletes one record from file
        /// </summary>
        /// <returns>Bool, BSTData object</returns>
        public bool DeleteById(out BSTData recData, int RRN)
        {
            recData = null;
            return false;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// reads one record from file
        /// </summary>
        /// <returns>bool, string containing rec</returns>
        public bool SelectByID(out BSTData aRec, short iD)
        {
            short rrn = HashFunction(iD);
            if (HashSearch(rrn, iD, out aRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //------------------------------------------------------------------------------
        /// <summary>
        /// inputs one record into file
        /// </summary>
        public int Output1Record(BSTData BSTRecord, short id)
        {
            string writeRecord;
            BSTRecord.HomeRRN = HashFunction(id);
            if (BSTRecord.HomeRRN == 31) // If beyond the size of the file wrap around to beginning
            {
                BSTRecord.HomeRRN = 1;
            }

            BSTData searchedRecord;
            short hashSearchRRN;
            if (HashSearch(BSTRecord.HomeRRN, out hashSearchRRN, out writeRecord, out searchedRecord)) // If hashSearch returns true
            {
                if (writeRecord == "Coll") // If a collision record
                {
                    BSTRecord.FinalRRN = BSTRecord.HomeRRN; // Set Final RRN for calculating later
                    int nFromHome = 0;
                    nCollRec++;
                    Read1Record(out returnNode, BSTRecord.FinalRRN); //Go to home location
                    while (Read1Record(out searchedRecord, BSTRecord.FinalRRN) && searchedRecord != null) // increment FinalRRN until find empty spot
                    {
                        BSTRecord.FinalRRN++;
                        if (BSTRecord.FinalRRN == 31) // Wrap around end of file
                        {
                            BSTRecord.FinalRRN = 1;
                        }
                        nFromHome++; // Calculate number from home location                        
                    }

                    BSTRecord.Location = ("C" + nFromHome.ToString().PadLeft(2, '0')).ToCharArray(); // Set as Collision and tell N from Home
                    BSTRecord.Link = returnNode.Link;

                    int offset = ((BSTRecord.HomeRRN - 1) * _sizeOfPhysicalDataRec) + _sizeOfHeaderRec;   // calculating offset for writing/reading links
                    
                    returnNode.Link = BSTRecord.FinalRRN; //Set home link(headPtr) to final spot of record

                    bCountryDataTableFileWriter.BaseStream.Seek(offset, SeekOrigin.Begin); // seek to write new link
                    RecordWriter(bCountryDataTableFileWriter, returnNode);  // new headptr

                    offset = ((BSTRecord.FinalRRN - 1) * _sizeOfPhysicalDataRec) + _sizeOfHeaderRec; // seek for new record
                    bCountryDataTableFileWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

                    SetPrivateValues(BSTRecord, BSTRecord.HomeRRN, BSTRecord.FinalRRN); // setting currentNode
                    RecordWriter(bCountryDataTableFileWriter, currentNode); // writing record
                    Console.WriteLine("Wrote to Collision:");

                    nRec++;
                    WriteHeaderRecord();
                    return BSTRecord.FinalRRN;
                }
                else
                {
                    BSTRecord.Location = "H  ".ToCharArray(); // else a home record and continue as if direct address random access
                    int offset = ((BSTRecord.HomeRRN - 1) * _sizeOfPhysicalDataRec) + _sizeOfHeaderRec;
                    bCountryDataTableFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    BSTRecord.FinalRRN = BSTRecord.HomeRRN;
                    SetPrivateValues(BSTRecord, BSTRecord.HomeRRN, BSTRecord.FinalRRN);
                    RecordWriter(bCountryDataTableFileWriter, currentNode);
                    Console.WriteLine("Wrote to HomeArea:");
                    nHomeRec++;
                    nRec++;
                    WriteHeaderRecord();
                    return BSTRecord.FinalRRN;
                }
            }
            return -1;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// reads one record from file
        /// </summary>
        /// <returns>bool, string containing rec</returns>
        public bool Read1Record(out BSTData aRec, short RRN)
        {
            ResetPrivatePublicValues();
            if (RRN == -1) // if not good record
            {
                formatRecord = Convert.ToString(RRN).PadLeft(3, '0') + "Empty";
                aRec = null;
                return false;
            }

            int offset = ((RRN - 1) * _sizeOfPhysicalDataRec) + _sizeOfHeaderRec;

            if (offset < bCountryDataTableFileReader.BaseStream.Length)
            {
                bCountryDataTableFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);
                currentNode.ID = bCountryDataTableFileReader.ReadInt16();
                currentNode.Code = bCountryDataTableFileReader.ReadChars(3);

                if (currentNode.Code[0] == '\0') // if empty
                {
                    formatRecord = Convert.ToString(RRN).PadLeft(3, '0') + "Empty";
                    aRec = null;
                    //SetPublicValues(aRec);
                    return true;
                }
                else
                {
                    // else a good record
                    if (ReadPrivateValues(bCountryDataTableFileReader))
                    {

                    }

                    formatRecord = "[" + Convert.ToString(currentNode.ID).PadLeft(3, '0') + "]".PadRight(2) +
                                    new string(currentNode.Code).PadRight(6) +
                                    new string(currentNode.Name).PadRight(18) +
                                    new string(currentNode.Continent).PadRight(12) +
                                    string.Format("{0:#,###,###.##}", currentNode.SurfaceArea).PadLeft(10) +
                                    string.Format("{0:#,###,###,###}", currentNode.Population).PadLeft(13).PadRight(12) +
                                    string.Format("{0:0.#}", currentNode.LifeExpectancy).PadRight(1).PadLeft(5) +
                                    Convert.ToString(currentNode.Link).PadLeft(5);
                    aRec = new BSTData(currentNode.ID, currentNode.Code, currentNode.Name, currentNode.Continent, currentNode.SurfaceArea, currentNode.Population,
                                       currentNode.LifeExpectancy, currentNode.Link);
                    aRec.HomeRRN = currentNode.HomeRRN;
                    aRec.FinalRRN = currentNode.FinalRRN;
                    aRec.Location = currentNode.Location;
                    SetPublicValues(aRec);
                    return true;
                }
            }
            else
            {
                //end of file
                aRec = null;
                return false;
            }
        }



        //**************************** PRIVATE METHODS *****************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// closing files and readers
        /// </summary>
        public void FinishUp(TheLog finishUpLog, bool printBool)
        {
            bCountryDataTableFileReader.Close();
            fCountryDataTableFile.Close();
            SnapShotUtility(finishUpLog, true);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// closing files and readers
        /// </summary>
        public void SnapShotUtility(TheLog snapLog, bool printTable)
        {
            fCountryDataTableFile = new FileStream("CountryDataTable.bin", FileMode.Open);
            bCountryDataTableFileReader = new BinaryReader(fCountryDataTableFile);

            int nRecord = bCountryDataTableFileReader.ReadInt16();

            string[] MainRecordList = ReadFile(bCountryDataTableFileReader, _sizeOfHeaderRec);

            PrintResults(snapLog, MainRecordList, nRecord);

            fCountryDataTableFile.Close();
            bCountryDataTableFileReader.Close();
        }

        //---------------------------------------------------------------------------------------------
        /// <summary>
        /// Loop through and store all viable records into a array
        /// </summary>
        /// <param name="fileReader">Current binary reader for the file being accessed</param>
        /// <param name="headerLength">Length (in bytes) of the header file</param>
        /// <returns>An array of formatted records ready to be displayed</returns>
        private static string[] ReadFile(BinaryReader fileReader, int headerLength)
        {
            short iD;
            char[] code;                           //Country code
            char[] name;                           //Name of country
            char[] continent;                      //What continent the country is located
            int surfaceArea;                      //Size of the country
            long population;                       //Total population of the country
            float lifeExpectancy;                  //The average time someone is alive in the country
            short link;
            int RRN = 1;
            string formatRecord;
            List<string> RecordCollection = new List<string>(); //List of formatted record strings

            for (long pos = headerLength; pos < fileReader.BaseStream.Length; pos += _sizeOfPhysicalDataRec, RRN++)
            {
                fileReader.BaseStream.Seek(pos, SeekOrigin.Begin);

                iD = fileReader.ReadInt16();
                code = fileReader.ReadChars(3);

                if (code[0] == '\0')
                {
                    formatRecord = "[" + Convert.ToString(RRN).PadLeft(3, '0') + "]".PadRight(2) + "Empty";
                }
                else
                {
                    name = fileReader.ReadChars(16);
                    continent = fileReader.ReadChars(13);
                    surfaceArea = fileReader.ReadInt32();
                    population = fileReader.ReadInt64();
                    lifeExpectancy = fileReader.ReadSingle();
                    link = fileReader.ReadInt16();


                    formatRecord = "[" + Convert.ToString(RRN).PadLeft(3, '0') + "]".PadRight(2) +
                                   "[" + Convert.ToString(iD).PadLeft(3, '0') + "]".PadRight(2) +
                                    new string(code).PadRight(6) +
                                    new string(name).PadRight(18) +
                                    new string(continent).PadRight(12) +
                                    string.Format("{0:#,###,###.##}", surfaceArea).PadLeft(10) +
                                    string.Format("{0:#,###,###,###}", population).PadLeft(14).PadRight(12) +
                                    string.Format("{0:0.#}", lifeExpectancy).PadRight(1).PadLeft(5) +
                                    link.ToString("D3").PadLeft(5);
                }

                RecordCollection.Add(formatRecord);
            }

            return RecordCollection.ToArray();

        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Formates the header to be displayed
        /// </summary>
        /// <returns>A ready to use string aligned in its columns</returns>
        private static string FormatHeader()
        {
            return "[RRN]".PadRight(6) +
                   "[ ID]".PadRight(6) +
                   "CODE".PadRight(6) +
                   "NAME".PadRight(18, '-') +
                   "CONTINENT".PadRight(12, '-') +
                   "AREA".PadLeft(7, '-').PadRight(12, '-') +
                   "POPULATION".PadLeft(12, '-').PadRight(13, '-') +
                   "L.EX".PadRight(6).PadLeft(6) +
                   "LINK".PadRight(6).PadLeft(6);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Print the results from the formatted text
        /// </summary>
        private void PrintResults(TheLog printLog, string[] MainDataList, int nRec)
        {
            string header = FormatHeader();

            printLog.DisplayALogRec("");
            printLog.DisplayALogRec("\n***************SNAPSHOT UTILITY STARTED***************\n");
            printLog.DisplayALogRec("COUNTRY DATA FILE".PadRight(header.Length + 1, '*'));
            printLog.DisplayALogRec(header);

            foreach (string s in MainDataList)
            {
                if (s != "")
                {
                    if (s.Substring(6, CountryDataTable.SizeOfRRN) == "\0\0\0" | s.Substring(6, CountryDataTable.SizeOfRRN) == "   ") //finish handling all variations of emtpy rec
                    {
                        printLog.DisplayALogRec((s.Substring(0, CountryDataTable.SizeOfRRN + 2) + " EMPTY"));
                    }
                    else
                    {
                        printLog.DisplayALogRec(s);
                    }
                }
                else
                {
                    printLog.DisplayALogRec((s.Substring(0, CountryDataTable.SizeOfRRN + 2) + " EMPTY"));
                }
            }

            printLog.DisplayALogRec("End".PadRight(header.Length + 1, '*'));
            printLog.DisplayALogRec("");

            printLog.DisplayALogRec("#Rec in COUNTRY TABLE FILE: " + nRec + " #HomeRec: " + nHomeRec + " #CollRec: " + nCollRec);
            printLog.DisplayALogRec("\n**********End Of SNAPSHOT UTILITY**********\n");
            printLog.DisplayALogRec("");
            printLog.DisplayALogRec("");
        }



        //------------------------------------------------------------------------------
        /// <summary>
        /// Writes fields to file
        /// </summary>
        private void RecordWriter(BinaryWriter fileWriter, BSTData countryDataRec)
        {
            fileWriter.Write(countryDataRec.ID);
            fileWriter.Write(countryDataRec.Code);
            fileWriter.Write(countryDataRec.Name);
            fileWriter.Write(countryDataRec.Continent);
            fileWriter.Write(countryDataRec.SurfaceArea);
            fileWriter.Write(countryDataRec.Population);
            fileWriter.Write(countryDataRec.LifeExpectancy);
            fileWriter.Write(countryDataRec.Link);
            fileWriter.Write(countryDataRec.HomeRRN);
            fileWriter.Write(countryDataRec.FinalRRN);
            fileWriter.Write(countryDataRec.Location);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Writes header record
        /// </summary>
        private void WriteHeaderRecord()
        {
            int offset = 0;
            bCountryDataTableFileWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

            bCountryDataTableFileWriter.Write(nRec);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// reads header record
        /// </summary>
        private void ReadHeaderRecord()
        {
            int offset = 0;
            bCountryDataTableFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);

            nRec = bCountryDataTableFileReader.ReadInt16();
            NRec = nRec;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// sets the public getters/setters
        /// </summary>
        private void SetPublicValues(BSTData aRec) // Setting Public Values for Easy Assigning
        {
            if (aRec != null)
            {
                publicNode = aRec;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Set the private values to their truncated values
        /// </summary>
        private void SetPrivateValues(BSTData BSTRecord, short privateHomeRRN, short privateFinalRRN)
        {
            StringBuilder nameBuilder = new StringBuilder(new string(BSTRecord.Name), 16);
            StringBuilder continentBuilder = new StringBuilder(new string(BSTRecord.Continent), 13);
            nameBuilder.Length = 16;
            continentBuilder.Length = 13;

            currentNode = new BSTData(BSTRecord.ID, new string(BSTRecord.Code).PadRight(CountryDataTable.SizeOfCode).ToCharArray(), nameBuilder.ToString().PadRight(CountryDataTable.SizeOfName).ToCharArray(),
                                      continentBuilder.ToString().PadRight(CountryDataTable.SizeOfContinent).ToCharArray(), BSTRecord.SurfaceArea, BSTRecord.Population, BSTRecord.LifeExpectancy, BSTRecord.Link);
            currentNode.HomeRRN = privateHomeRRN;
            currentNode.FinalRRN = privateFinalRRN;
            currentNode.Location = BSTRecord.Location;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Read the private values from file
        /// </summary>
        /// <returns>bool and a series of values for readonerecord</returns>
        private bool ReadPrivateValues(BinaryReader privateFileReader)
        {
            currentNode.Name = privateFileReader.ReadChars(16);
            currentNode.Continent = privateFileReader.ReadChars(13);
            currentNode.SurfaceArea = privateFileReader.ReadInt32();
            currentNode.Population = privateFileReader.ReadInt64();
            currentNode.LifeExpectancy = privateFileReader.ReadSingle();
            currentNode.Link = privateFileReader.ReadInt16();
            currentNode.HomeRRN = privateFileReader.ReadInt16();
            currentNode.FinalRRN = privateFileReader.ReadInt16();
            currentNode.Location = privateFileReader.ReadChars(3);
            return true;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Reset all values for next use
        /// </summary>
        private void ResetPrivatePublicValues()
        {
            currentNode = new BSTData(0, "/0/0/0".ToCharArray(), "/0/0/0".ToCharArray(), "/0/0/0".ToCharArray(), 0, 0, 0, -1);
            hashNode = null;
            writeNode = null;
            publicNode = null;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Sets a public size only accessible from this class to make life easier
        /// </summary>
        private void SetSize() // Setting the Size for fixed length fields
        {
            SizeOfRRN = sizeOfRRN;
            SizeOfCode = sizeOfCode;
            SizeOfName = sizeOfName;
            SizeOfContinent = sizeOfContinent;
            SizeOfSurfaceArea = sizeOfSurfaceArea;
            SizeOfPopulation = sizeOfPopulation;
            SizeOfLifeExpectancy = sizeOfLifeExpectancy;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// hashsearch for finding rec
        /// </summary>
        private bool HashSearch(short hashRRN, short hashID, out BSTData hashRec) // hashsearch for finding rec
        {
            if (Read1Record(out hashRec, hashRRN))
            {
                if (hashRec != null && hashID == hashRec.ID)
                {
                    return true; // found in home
                }
                else
                {
                    while (Read1Record(out hashRec, currentNode.Link) && hashRec != null)
                    {
                        if (hashID == hashRec.ID)
                        {
                            return true; // found in collision
                        }
                        hashRRN = currentNode.Link;
                    }
                    return false; // not found
                }
            }
            hashRec = null;
            return false;
        }
        //------------------------------------------------------------------------------
        /// <summary>
        /// hash search for finding location
        /// </summary>
        private bool HashSearch(short hashSearchID, out short homeRRN, out string fileChooser, out BSTData hashRecord) // hash search for finding location
        {
            List<BSTData> RecordCollection = new List<BSTData>(); //List of formatted record strings
            homeRRN = hashSearchID;
            if (Read1Record(out hashRecord, homeRRN))
            {
                fileChooser = "";

                if (hashRecord == null)
                {
                    fileChooser = "Home";
                }
                else
                {
                    fileChooser = "Coll";
                    while (Read1Record(out hashRecord, currentNode.Link) && hashRecord != null)
                    {
                        RecordCollection.Add(hashRecord);
                        if (hashSearchID == hashRecord.ID)
                        {
                            return true;
                        }
                        homeRRN = currentNode.Link;
                    }
                    return true;
                }
            }
            fileChooser = "Home";
            return true;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// hash function for calculating RRN
        /// </summary>
        private short HashFunction(short id)
        {
            short homeRRN;
            homeRRN = (short)(id % MAX_N_LOC);

            if (homeRRN == 0) { homeRRN = MAX_N_LOC; }

            return homeRRN;
        }
    }
}