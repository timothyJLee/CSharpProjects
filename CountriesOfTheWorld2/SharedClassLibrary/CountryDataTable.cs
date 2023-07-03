/* PROJECT: WorldDataAppCS (C#)         CLASS: CountryDataTable
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:
 *       INPUT: CountryDataTable.bin
 *       OUTPUT: CountryDataTable.bin, TheLog.txt
 * FILE STRUCTURE:  Direct Address, Random Access
 * DESCRIPTION:  An OOP class with constructors, public getters/setters, private vars and methods, and public methods,
 *             for input of data records and reading data records from a CountryDataTable.txt file. Uses a direct address file 
 *             structure with fixed length fields and records.  Contains the ability to create or open CountryDataTable.txt in
 *             Constructor, as well as the ability to read a record, write a record, delete a record, or close the data File.
*******************************************************************************/

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace SharedClassLibrary
{
    public class CountryDataTable
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private static FileStream fCountryDataTableFile;
        private static BinaryReader bCountryDataTableFileReader;
        private static BinaryWriter bCountryDataTableFileWriter;
        private static int _sizeOfHeaderRec = sizeof(short);
        private static int _sizeOfPhysicalDataRec = 3 * sizeof(char) + 16 * sizeof(char) + 13 * sizeof(char) + sizeof(int) + sizeof(long) + sizeof(float);

        private char[] code = new char[3];                           //Country code
        private char[] name = new char[16];                           //Name of country
        private char[] continent = new char[13];                      //What continent the country is located
        private int surfaceArea;                      //Size of the country
        private long population;                       //Total population of the country
        private float lifeExpectancy;                  //The average time someone is alive in the country

        private int CountryDataTableRRN;
        private string formatRecord;

        //  Setting the sizes of the fixed length records first in main data
        private static int sizeOfRRN = 3;
        private static int sizeOfCode = 3;
        private static int sizeOfName = 16;
        private static int sizeOfContinent = 13;
        private static int sizeOfSurfaceArea = 9; //sizeof(int);
        private static int sizeOfPopulation = 10; // sizeof(long);
        private static int sizeOfLifeExpectancy = 4; //sizeof(float);

        ////  For keeping count of total records
        private static short N = 0;

        private const string empty = "\0\0\0";


        //**************************** PUBLIC GET/SET METHODS **********************
        public static int SizeOfRRN { get; set; }
        public static int SizeOfCode { get; set; }
        public static int SizeOfName { get; set; }
        public static int SizeOfContinent { get; set; }
        public static int SizeOfSurfaceArea { get; set; }
        public static int SizeOfPopulation { get; set; }
        public static int SizeOfLifeExpectancy { get; set; }

        public static int Count { get; set; }
        public static int ErrorCount { get; set; }

        public string RRNS { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string SurfaceArea { get; set; }
        public string Population { get; set; }
        public string LifeExpectancy { get; set; }

        public static short NRec { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public CountryDataTable(string createFile) // Constructor for Creating a CountryDataTable.bin File
        {
            try
            {
                fCountryDataTableFile = new FileStream("CountryDataTable.bin", FileMode.Create);
                bCountryDataTableFileReader = new BinaryReader(fCountryDataTableFile);
                bCountryDataTableFileWriter = new BinaryWriter(fCountryDataTableFile);
                SetSize();
                N = 0; // Set count variables upon creation of CountryDataTable.bin
                Count = 0;
                ErrorCount = 0;
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
        public bool Delete1Record(out BSTData recData, int RRN)
        {
            recData = new BSTData(-1, "", "", "", "0", "0", "0");

            ResetPrivatePublicValues();

            if (RRN == -1)
            {
                formatRecord = Convert.ToString(RRN).PadLeft(3, '0') + "Empty";
                return false;
            }

            int offset = ((RRN - 1) * _sizeOfPhysicalDataRec) + _sizeOfHeaderRec;
            bCountryDataTableFileWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

            SetPrivateValues(recData, RRN);
            RecordWriter(bCountryDataTableFileWriter);
            return true;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// inputs one record into file
        /// </summary>
        public void Input1Record(BSTData BSTRecord, int RRN)
        {
            int offset = ((RRN - 1) * _sizeOfPhysicalDataRec) + _sizeOfHeaderRec;
            bCountryDataTableFileWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

            SetPrivateValues(BSTRecord, RRN);
            RecordWriter(bCountryDataTableFileWriter);
            N++;
            WriteHeaderRecord();
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// reads one record from file
        /// </summary>
        /// <returns>bool, string containing rec</returns>
        public bool Read1Record(out string aRec, int RRN)
        {
            ResetPrivatePublicValues();
            if (RRN == -1)
            {
                formatRecord = Convert.ToString(RRN).PadLeft(3, '0') + "Empty";
                aRec = "";
                return false;
            }

            int offset = ((RRN - 1) * _sizeOfPhysicalDataRec) + _sizeOfHeaderRec;

            if (offset < bCountryDataTableFileReader.BaseStream.Length)
            {
                bCountryDataTableFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);
                code = bCountryDataTableFileReader.ReadChars(3);
                for (int i = 0; i < 3; i++)
                {
                    Code += code[i];
                }

                if (code[0] == ' ')
                {
                    formatRecord = Convert.ToString(RRN).PadLeft(3, '0') + "Empty";
                    aRec = "";
                    SetPublicValues(aRec);
                    return true;
                }
                else
                {
                    if (ReadPrivateValues(bCountryDataTableFileReader, out name, out continent, out surfaceArea, out population, out lifeExpectancy))
                    {
                        for (int i = 0; i < name.Length; i++)
                        {
                            Name += name[i];
                        }
                        for (int i = 0; i < continent.Length; i++)
                        {
                            Continent += continent[i];
                        }
                    }

                    StringBuilder nameBuilder = new StringBuilder(new string(name), 16);
                    StringBuilder continentBuilder = new StringBuilder(new string(continent), 13);
                    nameBuilder.Length = 16;
                    continentBuilder.Length = 13;


                    formatRecord = "[" + Convert.ToString(RRN).PadLeft(3, '0') + "]".PadRight(2) +
                                    new string(code).PadRight(6) +
                                    nameBuilder +
                                    continentBuilder +
                                    string.Format("{0:#,###,###.##}", surfaceArea).PadLeft(10) +
                                    string.Format("{0:#,###,###,###}", population).PadLeft(13).PadRight(12) +
                                    string.Format("{0:0.#}", lifeExpectancy).PadRight(1).PadLeft(5);
                    aRec = formatRecord;
                    SetPublicValues(aRec);
                    return true;
                }
            }
            else
            {
                //end of file
                aRec = "";
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
            SnapShotUtility(finishUpLog, printBool);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// closing files and readers
        /// </summary>
        private void SnapShotUtility(TheLog snapLog, bool printTable)
        {
            fCountryDataTableFile = new FileStream("CountryDataTable.bin", FileMode.Open);
            bCountryDataTableFileReader = new BinaryReader(fCountryDataTableFile);
            int nRecord = bCountryDataTableFileReader.ReadInt16();
            string[] MainRecordList = ReadFile(bCountryDataTableFileReader, _sizeOfHeaderRec);
            PrintResults(MainRecordList, snapLog, nRecord);
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
            char[] code;                           //Country code
            char[] name;                           //Name of country
            char[] continent;                      //What continent the country is located
            int surfaceArea;                      //Size of the country
            long population;                       //Total population of the country
            float lifeExpectancy;                  //The average time someone is alive in the country
            int RRN = 1;
            string formatRecord;
            List<string> RecordCollection = new List<string>(); //List of formatted record strings

            for (long pos = headerLength; pos < fileReader.BaseStream.Length; pos += _sizeOfPhysicalDataRec, RRN++)
            {
                fileReader.BaseStream.Seek(pos, SeekOrigin.Begin);

                code = fileReader.ReadChars(3);

                if (code[0] == '\0')
                {
                    formatRecord = "[" + Convert.ToString(RRN).PadLeft(3, '0') + "]".PadRight(2) + "Empty";
                }
                else
                {
                    fileReader.ReadChars(1);
                    name = fileReader.ReadChars(16);
                    continent = fileReader.ReadChars(13);
                    surfaceArea = fileReader.ReadInt32();
                    population = fileReader.ReadInt64();
                    lifeExpectancy = fileReader.ReadSingle();


                    formatRecord = "[" + Convert.ToString(RRN).PadLeft(3, '0') + "]".PadRight(2) +
                                    new string(code).PadRight(6) +
                                    new string(name).PadRight(18) +
                                    new string(continent).PadRight(12) +
                                    string.Format("{0:#,###,###.##}", surfaceArea).PadLeft(10) +
                                    string.Format("{0:#,###,###,###}", population).PadLeft(13).PadRight(12) +
                                    string.Format("{0:0.#}", lifeExpectancy).PadRight(1).PadLeft(5);
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
                   "CODE".PadRight(6) +
                   "NAME".PadRight(18, '-') +
                   "CONTINENT".PadRight(12, '-') +
                   "AREA".PadLeft(7, '-').PadRight(12, '-') +
                   "POPULATION".PadLeft(12, '-').PadRight(13, '-') +
                   "L.EX".PadRight(6).PadLeft(6);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Print the results from the formatted text
        /// </summary>
        private static void PrintResults(string[] MainDataList, TheLog logFile, int nRec)
        {
            string header = FormatHeader();

            logFile.DisplayALogRec("");
            logFile.DisplayALogRec("\n***************SNAPSHOT UTILITY STARTED***************\n");
            logFile.DisplayALogRec("COUNTRY DATA FILE".PadRight(header.Length + 1, '*'));
            logFile.DisplayALogRec(header);

            foreach (string s in MainDataList)
            {
                if (s != "")
                {
                    if (s.Substring(6, CountryDataTable.SizeOfRRN) == "\0\0\0" | s.Substring(6, CountryDataTable.SizeOfRRN) == "   ") //finish handling all variations of emtpy rec
                    {
                        logFile.DisplayALogRec((s.Substring(0, CountryDataTable.SizeOfRRN + 2) + " EMPTY"));
                    }
                    else
                    {
                        logFile.DisplayALogRec(s);
                    }
                }
                else
                {
                    logFile.DisplayALogRec((s.Substring(0, CountryDataTable.SizeOfRRN + 2) + " EMPTY"));
                }
            }

            logFile.DisplayALogRec("End".PadRight(header.Length + 1, '*'));
            logFile.DisplayALogRec("");

            logFile.DisplayALogRec("#Rec in COUNTRY TABLE FILE: " + nRec);
            logFile.DisplayALogRec("\n**********End Of SNAPSHOT UTILITY**********\n");
            logFile.DisplayALogRec("");
            logFile.DisplayALogRec("");
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Writes fields to file
        /// </summary>
        private void RecordWriter(BinaryWriter fileWriter)
        {
            fileWriter.Write(code);
            fileWriter.Write(name);
            fileWriter.Write(continent);
            fileWriter.Write(surfaceArea);
            fileWriter.Write(population);
            fileWriter.Write(lifeExpectancy);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Writes header record
        /// </summary>
        private void WriteHeaderRecord()
        {
            int offset = 0;
            bCountryDataTableFileWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

            bCountryDataTableFileWriter.Write(N);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// reads header record
        /// </summary>
        private void ReadHeaderRecord()
        {
            int offset = 0;
            bCountryDataTableFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);

            N = bCountryDataTableFileReader.ReadInt16();
            NRec = N;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// sets the public getters/setters
        /// </summary>
        private void SetPublicValues(string aRec) // Setting Public Values for Easy Assigning
        {
            if (aRec != "")
            {
                Code = "";
                Name = "";
                Continent = "";

                RRNS = Convert.ToString(CountryDataTableRRN).PadLeft(3, '0');

                foreach (char c in code)
                {
                    Code += c.ToString();
                }
                Code = Code.PadRight(6);
                foreach (char c in name)
                {
                    Name += c.ToString();
                }
                Name = Name.PadRight(16);
                foreach (char c in continent)
                {
                    Continent += c.ToString();
                }

                Continent = Continent.PadRight(13);
                SurfaceArea = string.Format("{0:#,###,###.##}", surfaceArea);
                Population = string.Format("{0:#,###,###,###}", population);
                LifeExpectancy = string.Format("{0:0.#}", lifeExpectancy);
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Set the private values to their truncated values
        /// </summary>
        private void SetPrivateValues(BSTData BSTRecord, int privateRRN)
        {
            CountryDataTableRRN = privateRRN;

            code = BSTRecord.Code.PadRight(CountryDataTable.SizeOfCode).ToCharArray();

            name = BSTRecord.Name.PadRight(CountryDataTable.SizeOfName).ToCharArray();

            continent = BSTRecord.Continent.PadRight(CountryDataTable.SizeOfContinent).ToCharArray();

            StringBuilder nameBuilder = new StringBuilder(new string(name), 16);
            StringBuilder continentBuilder = new StringBuilder(new string(continent), 13);
            nameBuilder.Length = 16;
            continentBuilder.Length = 13;

            name = nameBuilder.ToString().ToCharArray();
            continent = continentBuilder.ToString().ToCharArray();

            if (BSTRecord.SurfaceArea != "NULL")
            {
                surfaceArea = int.Parse(BSTRecord.SurfaceArea.PadRight(CountryDataTable.SizeOfSurfaceArea));
            }

                population = (long)int.Parse(BSTRecord.Population.PadRight(CountryDataTable.SizeOfPopulation));
           
            if (BSTRecord.LifeExpectancy != "NULL" && BSTRecord.LifeExpectancy != "")
            {
                lifeExpectancy = float.Parse(BSTRecord.LifeExpectancy.PadRight(CountryDataTable.SizeOfLifeExpectancy));
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Read the private values from file
        /// </summary>
        /// <returns>bool and a series of values for readonerecord</returns>
        private bool ReadPrivateValues(BinaryReader privateFileReader, out char[] privName, out char[] privContinent, out int privSurfaceArea,
                                                                     out long privPopulation, out float privLifeExpectancy)
        {
            privateFileReader.ReadChars(1);
            privName = privateFileReader.ReadChars(16);
            privContinent = privateFileReader.ReadChars(13);
            privSurfaceArea = privateFileReader.ReadInt32();
            privPopulation = privateFileReader.ReadInt64();
            privLifeExpectancy = privateFileReader.ReadSingle();
            return true;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Reset all values for next use
        /// </summary>
        private void ResetPrivatePublicValues()
        {
            RRNS = "";
            Code = "";
            Name = "";
            Continent = "";
            SurfaceArea = "";
            Population = "";
            LifeExpectancy = "";

            CountryDataTableRRN = 1;
            code = "".ToCharArray();
            name = "".ToCharArray(); ;
            continent = "".ToCharArray();
            surfaceArea = 0;
            population = 0;
            lifeExpectancy = 0;
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
    }
}