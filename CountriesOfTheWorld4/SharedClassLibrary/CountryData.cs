/* PROJECT: WorldDataAppCS (C#)         CLASS: CountryData
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:
 *       INPUT: CountryDataTable.txt
 *       OUTPUT: CountryDataTable.txt, TheLog.txt
 * FILE STRUCTURE:  Direct Address, Random Access
 * DESCRIPTION:  An OOP class with constructors, public getters/setters, private vars and methods, and public methods,
 *             for input of data records and reading data records from a CountryDataTable.txt file. Uses a random access 
 *             structure with fixed length fields and records.  Contains the ability to open CountryDataTable.txt in
 *             Constructor, as well as the ability to read a record or close the data File.
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace SharedClassLibrary
{
    public class CountryData
    {
        //**************************** PRIVATE DECLARATIONS ************************

        private string iD;
        private string code;
        private string stringField;
        private string numField;

        private StreamReader CountryDataStreamReader;
        private static FileStream fCountryDataFile;
        private static BinaryReader bCountryDataFileReader; //declaring binary I/Os
        private static BinaryWriter bCountryDataFileWriter;
        private static int _sizeOfPhysicalDataRec = 25;

        //**************************** PUBLIC GET/SET METHODS **********************
        public static int FileNum;
        public string ID { get { return iD; } set { iD = value; } }
        public string Code { get { return code; } set { code = value; } }
        public string StringField { get { return stringField; } set { stringField = value; } }
        public string NumField { get { return numField; } set { numField = value; } }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public CountryData(short fileNum)
        {
            FileNum = fileNum;
            fCountryDataFile = new FileStream("CountryData" + FileNum + ".txt", FileMode.Open);
            bCountryDataFileReader = new BinaryReader(fCountryDataFile);
            bCountryDataFileWriter = new BinaryWriter(fCountryDataFile);
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Get one CountryData Record to pass into SetupProgram
        /// </summary>
        public bool Input1Record()
        {
            string theLine = CountryDataStreamReader.ReadLine();
            if (theLine != "")
            {
                string[] lineSplit = theLine.Split(' ');
                iD = lineSplit[0];
                code = lineSplit[1];
                stringField = lineSplit[2];
                numField = lineSplit[3];
                return true;
            }
            else
            {           // at end of CountryDataFile
                iD = code = stringField = numField = "";
                return false;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Get one CountryData Record to pass into SetupProgram
        /// </summary>
        public bool Find1Record(int passedID)
        {
            if (passedID == -1)
            {
                return false; // negative 1 is end
            }

            int offset = ((passedID - 1) * _sizeOfPhysicalDataRec);

            if (offset < bCountryDataFileReader.BaseStream.Length)
            {
                bCountryDataFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);

                iD = new string(bCountryDataFileReader.ReadChars(2));

                if (iD == "  ")
                {
                    return false;
                }

                bCountryDataFileReader.ReadChar();
                code = new string(bCountryDataFileReader.ReadChars(3));
                bCountryDataFileReader.ReadChar();
                stringField = new string(bCountryDataFileReader.ReadChars(10));
                bCountryDataFileReader.ReadChar();
                numField = new string(bCountryDataFileReader.ReadChars(5));
                return true;
            }
            else
            {
                return false; //end of file
            }
        }

        //**************************** PRIVATE METHODS *****************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// FinishUp and close file
        /// </summary>
        public void FinishUp(TheLog finishUpLog)
        {      // providing counts and closing files
            fCountryDataFile.Close();
            bCountryDataFileReader.Close();
            bCountryDataFileWriter.Close();
        }
    }
}
