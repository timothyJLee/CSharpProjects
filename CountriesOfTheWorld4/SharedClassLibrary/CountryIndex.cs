/* PROJECT: WorldDataAppCS (C#)         CLASS: CountryIndex
 * AUTHOR: Timothy Lee / CS3310
 * FILES ACCESSED:
 *       INPUT: CountryIndex.bin
 *       OUTPUT: CountryIndex.bin, TheLog.txt
 * FILE STRUCTURE:  B-tree, index
 * DESCRIPTION:  An OOP class with constructors, public getters/setters, private vars and methods, and public methods,
 *             for reading data records from a CountryIndex.bin file. Uses a random access 
 *             structure with fixed length fields and records.  Contains the ability to open CountryIndex.bin in
 *             Constructor, as well as the ability to read a record, return an indexed DRP or close the data File.
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
    public class CountryIndex
    {
        //**************************** PRIVATE DECLARATIONS ************************

        private short M;
        private short rootPtr;
        private short N;

        private short[] TP;
        private string[] KV;
        private short[] DRP;

        private short nodesRead;

        private static FileStream fCountryIndexFile;
        private static BinaryReader bCountryIndexFileReader; //declaring binary I/Os
        private static BinaryWriter bCountryIndexFileWriter;
        private static int _sizeOfHeaderRec = sizeof(short) * 3;  // declaring sizes of memory structures for seeking in file
        private static int _sizeOfPhysicalIndexRec;


        //**************************** PUBLIC GET/SET METHODS **********************
        public short NodesRead { get { return nodesRead; } set { nodesRead = value; } }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public CountryIndex(string create, short FileNum)
        {
            M = 0;
            rootPtr = 0;
            N = 0;

            fCountryIndexFile = new FileStream("CodeIndex" + FileNum + ".bin", FileMode.Open);
            bCountryIndexFileReader = new BinaryReader(fCountryIndexFile);
            bCountryIndexFileWriter = new BinaryWriter(fCountryIndexFile);

            ReadHeaderRecord();
            _sizeOfPhysicalIndexRec = (sizeof(short) * M) + ((3) * (M - 1)) + (sizeof(short) * (M - 1));
            InitializeArrays();
        }
        public CountryIndex(short FileNum)
        {
            fCountryIndexFile = new FileStream("CodeIndex" + FileNum + ".bin", FileMode.Open);
            bCountryIndexFileReader = new BinaryReader(fCountryIndexFile);
            bCountryIndexFileWriter = new BinaryWriter(fCountryIndexFile);

            InitializeArrays();
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Select One Index Entry By Code
        /// </summary>
        public bool SelectByCode(char[] selectCode, out short DRP)
        {
            if (Search1Node(selectCode, out DRP))
            {
                return true;
            }
            return false;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Read a Node based off of Passed Ptr or Link
        /// </summary>
        private bool Read1Node(int index)
        {
            if (index == -1)
            {
                return false;
            }

            //int offset = ((index) * ((M - 1) * (int)_sizeOfPhysicalIndexRec + 2));
            int offset = ((index - 1) *_sizeOfPhysicalIndexRec + _sizeOfHeaderRec);

            if (offset < bCountryIndexFileReader.BaseStream.Length)
            {
                bCountryIndexFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);

                int i = 0;
                byte[] bytes;
                for (i = 0; i < M ; i++)
                {
                 TP[i] = bCountryIndexFileReader.ReadInt16();
                    bytes = BitConverter.GetBytes(TP[i]); // for converting endianess
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes);
                        TP[i] = BitConverter.ToInt16(bytes, 0);
                    }
                }
                for (i = 0; i < M - 1 ; i++)
                {
                    KV[i] = new string(bCountryIndexFileReader.ReadChars(3));
                }
                for (i = 0; i < M - 1; i++)
                {
                    DRP[i] = bCountryIndexFileReader.ReadInt16();
                    bytes = BitConverter.GetBytes(DRP[i]);
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes);
                        DRP[i] = BitConverter.ToInt16(bytes, 0);
                    }
                }

                if (KV[M-1] == "/0/0/0")
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false; //end of file
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Search one node or Pass Tree Pointer to Search Next Nodes
        /// </summary>
        private bool Search1Node(char[] searchCode, out short searchDRP)
        {
            nodesRead = 0;
            int i = rootPtr;
            while (i != -1 && Read1Node(i))
            {
                int j = 0;
                for (j = 0; j < M ;)
                {
                    if (new string(searchCode).CompareTo(KV[j]) > 0)
                    {
                        if (KV[j] == "]]]")
                        {
                            i = TP[j];
                            break;
                        }
                        j++;
                    }
                    else
                    {
                        if (new string(searchCode).CompareTo(KV[j]) != 0)
                        {
                            i = TP[j];
                            break;
                        }
                        else
                        {
                            searchDRP = DRP[j];
                            return true;
                        }
                    }
                    nodesRead++;
                }
            }
            searchDRP = -1;
            return false;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// reads header record
        /// </summary>
        private void ReadHeaderRecord()
        {
            int offset = 0;
            bCountryIndexFileReader.BaseStream.Seek(offset, SeekOrigin.Begin);

            M = bCountryIndexFileReader.ReadInt16();
            byte[] bytes = BitConverter.GetBytes(M);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
                M = BitConverter.ToInt16(bytes,0);
            }
                

            rootPtr = bCountryIndexFileReader.ReadInt16();
            bytes = BitConverter.GetBytes(rootPtr);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
                rootPtr = BitConverter.ToInt16(bytes,0);
            }
                

            N = bCountryIndexFileReader.ReadInt16();
            bytes = BitConverter.GetBytes(N);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
                N = BitConverter.ToInt16(bytes, 0);
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Initializes Arrays
        /// </summary>
        private void InitializeArrays()
        {
            TP = new short[M];
            KV = new string[M];
            DRP = new short[M - 1];
            
                KV[M-1] = "]]]";
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// FinishUp and close file
        /// </summary>
        public void FinishUp(TheLog finishUpLog)
        {      // providing counts and closing files
            fCountryIndexFile.Close();
            bCountryIndexFileReader.Close();
            bCountryIndexFileWriter.Close();
        }
    }
}
