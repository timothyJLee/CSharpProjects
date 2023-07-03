// PROGRAM:  WorldDataBaseA6
// AUTHOR:  Timothy Lee
// SOFTWARE:  Visual Studio 2012, MySQL 5.1; MySQL Connector Net 6.3.5
//
// *************************************************************************************
// DESCRIPTION: This program USES the World DB.  It assumes the DB's already set up.
//      This set up was done directly in mysql by using script files to
//          CREATE the database, CREATE its tables (with column descriptions),
//          and populate the tables with actual data using INSERTs.
//      Such operations as CREATE, DROP, ALTER (i.e., DDL, Data Definition Language,
//          SQL commands which affect the DB Schema) COULD have been done by a C#
//          program instead.  That's something you can explore later in a DBS course.
//      This program only queries & manipulates the DATA itself using DML (Data
//          Manipulation Language) SQL commands: SELECT, INSERT, DELETE, UPDATE.
//
// *************************************************************************************
// DISCLAIMER:  This program is simplified in order to demonstrate what's needed for
//      a C# program to access a MySQL database.  It uses hard-coded SQL strings right
//      in the program itself, each in its own specific method.  This is poor 
//      programming practice.  First, it is not generic and robust, with the SQL
//      commands actually hard-coded in the program and an individual method defined
//      for each SQL statement.  Secondly, this approaches leaves the database open
//      to security problems, allowing the general program direct access to the
//      database, with possibly questionable SQL statements.


using System;
using System.IO;

using System.Data;                      
using MySql.Data;                          
using MySql.Data.MySqlClient;               

namespace WorldDataBaseA6
{
    class Program
    {
        static void Main()
        {
            string password = "EDITEDOUT";          // COULD ASK USER FOR THIS INSTEAD

            string connStr = "server=localhost;user=root;database=world;" +
                "port=3306;password=" + password + ";";  //  assigning the connection string

            StringHandling sqlQueryFormatter = new StringHandling();

            MySqlConnection conn;

            StreamWriter logFile = new StreamWriter("WorldLogFile.txt");  // for writing to log
            StreamReader transFile = new StreamReader("WorldTrans.txt");

            string transactionString;

            logFile.WriteLine("Connecting to MySQL...");

            try
            {
                int i = 0;
                conn = new MySqlConnection(connStr);
                conn.Open();
                logFile.WriteLine("OK, the DB Connection is OPENED\n");

                while (!transFile.EndOfStream)         // Main While Loop
                {
                    transactionString = transFile.ReadLine();
                    sqlQueryFormatter.SubDivideString(transactionString);
                    switch (sqlQueryFormatter.TransactionCode)
                    {
                        case 'S':
                            if (sqlQueryFormatter.SQLQueryString.Substring(7, 8) == "COUNT(*)")
                            {
                                DataRetrieval.DoQueryWhichGetsSingleValue(conn, logFile, sqlQueryFormatter.SQLQueryString, i);
                            }
                            else
                            {
                                if (sqlQueryFormatter.SQLQueryString.Substring(7, 1) == "*")
                                {

                                    DataRetrieval.DoQueryOnCK(conn, logFile, sqlQueryFormatter.SQLQueryString, i);
                                }
                                else
                                {
                                    DataRetrieval.DoQueryWhichGetsMultRows(conn, logFile, sqlQueryFormatter.SQLQueryString, i);
                                }
                            }
                            break;
                        case 'I':
                            DataUpdate.DoInsert(conn, logFile, sqlQueryFormatter.SQLQueryString, i, sqlQueryFormatter);
                            break;
                        case 'D':
                            DataUpdate.DoDelete(conn, logFile, sqlQueryFormatter.SQLQueryString, i, sqlQueryFormatter);
                            break;
                        case 'U':
                            DataUpdate.DoUpdate(conn, logFile, sqlQueryFormatter.SQLQueryString, i, sqlQueryFormatter);
                            DataRetrieval.DoQueryToCheckUpdate(conn, logFile, sqlQueryFormatter.SQLQueryString, i);
                            break;
                    }
                    i++;
                }
                conn.Close();  //Closing Connection
            }
            catch (Exception ex)
            {
                logFile.WriteLine("\r\nERROR, DB Connection didn't work - no trans done");
                logFile.WriteLine(ex.ToString());
            }

            logFile.WriteLine("\r\nEXITING PROGRAM");
            logFile.Close();
        }
    }
}
