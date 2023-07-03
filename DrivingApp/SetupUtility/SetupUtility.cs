/* PROJECT:  DrivingAppA5 (C#)            PROGRAM: SetupUtility
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 5): UI
 * FILES ACCESSED:   Roads.bin, CityNames.txt, MapData.txt
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      Creates a sequential CityNames file from data in the MapData file and a Roads.bin file
 *          
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with MapData
 *      {   input 1 data set from MapData
 *      }
 *      finish up with MapDAta
 *      finish up with Roads.Bin
 *      finish up with CityNames.txt
 *      PretyPrint too
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      RawData or CountryDataTable or Log.  Appropriate OOP classes handle those.   
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SharedClassLibrary;

namespace SetupUtility
{
    public class SetupUtility
    {

        public static void Main(string[] args)
        {            
            string filePrefixString = args[0];

            UI setupLog = new UI(filePrefixString);

            FileStream mapDataFile = File.Open((filePrefixString + "MapData.txt"), FileMode.Open, FileAccess.Read);
            StreamReader mapDataStreamReader = new StreamReader(mapDataFile);

            FileStream cityNamesFile = File.Open((filePrefixString + "CityNames.txt"), FileMode.Create, FileAccess.ReadWrite);
            StreamWriter cityNamesStreamWriter = new StreamWriter(cityNamesFile);

            FileStream roadsFile = new FileStream((filePrefixString + "Roads.bin"), FileMode.Create);
            BinaryReader bRoadsFileReader = new BinaryReader(roadsFile);
            BinaryWriter bRoadsFileWriter = new BinaryWriter(roadsFile);

            char graphType;
            short N = 0;
            short[,] RoadDistanceMatrix;
            string[] cityNamesArray;

            InitializeMapData(out RoadDistanceMatrix, out N, out graphType, mapDataStreamReader, out cityNamesArray); // Assigning Everything from Files
            OutputToCityNamesFile(cityNamesArray, cityNamesStreamWriter); //Outputting to CityNAmes File
            OutputToRoadsFile(bRoadsFileWriter, N, graphType, RoadDistanceMatrix);  // Outputting to Roads.bin file

            bRoadsFileReader.Close();
            cityNamesStreamWriter.Close();
            cityNamesFile.Close();
            roadsFile.Close();  // Closing files and preparing for the PrettyPrint

            roadsFile = new FileStream((filePrefixString + "Roads.bin"), FileMode.Open);
            cityNamesFile = File.Open((filePrefixString + "CityNames.txt"), FileMode.Open, FileAccess.ReadWrite);
            bRoadsFileReader = new BinaryReader(roadsFile);
            StreamReader cityNamesStreamReader = new StreamReader(cityNamesFile);
            PrettyPrint(bRoadsFileReader, cityNamesStreamReader, N, filePrefixString, setupLog); // PrettyPrinting After Preparing

            mapDataFile.Close();
            mapDataStreamReader.Close();

            cityNamesFile.Close();
            cityNamesStreamReader.Close();
            cityNamesStreamWriter.Close();

            roadsFile.Close();
            bRoadsFileReader.Close();
            bRoadsFileWriter.Close();  // CLosing lots of stuff

            setupLog.FinishUp();  // Finishing up
        }

        static void InitializeMapData(out short[,] internalAdjacencyMatrix, out short N, out char graphType,
                                      StreamReader mapDataReader, out string[] cityNamesArray)
        {
            string[] Record;
            graphType = 'X';
            N = 0;
            internalAdjacencyMatrix = new short[N, N];
            short index = 0;
            cityNamesArray = new string[N];

            while (Input1MapDataRecord(mapDataReader, out Record))
            {
                if (Record[0] != "%")
                {
                    switch (Record.Length)
                    {
                        case 1: // Case1 is city name
                            cityNamesArray[index] = Record[0];
                            index++;
                            break;
                        case 2: // Case2 is Header so graph initialization is possible
                            graphType = Record[0].ToCharArray()[0];
                            N = short.Parse(Record[1]);
                            cityNamesArray = new string[N];
                            internalAdjacencyMatrix = new short[N, N];
                            for (int i = 0; i < N; i++)
                            {
                                for (int j = 0; j < N; j++)
                                {
                                    if (i == j)
                                    {
                                        internalAdjacencyMatrix[i, j] = 0;
                                    }
                                    else
                                    {
                                        internalAdjacencyMatrix[i, j] = short.MaxValue;
                                    }
                                }
                            }   
                            break;
                        case 3: // Edge Weight and needs to be put in proper spot
                            internalAdjacencyMatrix[int.Parse(Record[0]), int.Parse(Record[1])] = short.Parse(Record[2]);
                            break;
                    }
                }
                else
                {
                    // A comment
                }
            }            
        }


        //------------------------------------------------------------------------------
        /// <summary>
        /// Get one MapData Record to pass into SetupProgram
        /// </summary>
        static bool Input1MapDataRecord(StreamReader mapDataStreamReader, out string[] Record)
        {
            string theLine = mapDataStreamReader.ReadLine();
            
            Record = new string[0];

            if (theLine != null)
            {
                string[] lineSplit = theLine.Split(' ');
                Record = lineSplit;
                return true;
            }
            else
            {
                return false;
            }                
        }

        static void OutputToRoadsFile(BinaryWriter bRoadsWriter, short N, char graphType, short[,] RoadDistanceMatrix)  // Outputting to Roads.bin External Adjacency Matrix
        {
            bRoadsWriter.Write(graphType);
            bRoadsWriter.Write(N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    bRoadsWriter.Write(RoadDistanceMatrix[i,j]);
                }
            }
        }

        static void OutputToCityNamesFile(string[] cityNamesArray, StreamWriter cityNamesStreamWriter)  // Outputting to External City Names file
        {
            for (int i = 0; i < cityNamesArray.Length; i++)
            {
                cityNamesStreamWriter.WriteLine(cityNamesArray[i]);
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// SnapShot
        /// </summary>
        static void PrettyPrint(BinaryReader bRoadsReader, StreamReader mapDataStreamReader, short N,   // Printing files to make sure everything went okay
                                string fileString, UI PrettyPrintLog)
        {
            PrettyPrintLog.WriteThis(" ");
            PrettyPrintLog.WriteThis("Map Data:   " + fileString + "     Number of cities:   " + N);
            
            while (!mapDataStreamReader.EndOfStream)
            {
                PrettyPrintLog.WriteThis(mapDataStreamReader.ReadLine());
            }

            bRoadsReader.ReadChar();
            PrettyPrintLog.WriteThis(Header(bRoadsReader.ReadInt16()));

            string formatString = "";
                for(int i = 0; i < N; i++)
                {
                    formatString = "";
                    for (int j = 0; j < N; j++)
                    {
                        formatString += bRoadsReader.ReadInt16().ToString().PadLeft(6).PadRight(6, ' ');
                    }
                    PrettyPrintLog.WriteThis(i.ToString().PadLeft(2) + "|" + formatString);
                }                
        }

        static string Header(short N) // Formatting a header of approapriate size
        {
            string headerString = "   ";
            string lineString = "   ";

            for (int i = 0; i < N; i++)
            {
                headerString += i.ToString().PadLeft(6).PadRight(6, ' ');
            }
            headerString += Environment.NewLine;
            for (int i = 0; i < headerString.Length - 5; i++)
            {
                lineString += "-";
            }
            headerString += lineString;

            return headerString;
        }
    }          
}
