// CLASS:  DataRetrieval      used by PROGRAM:  WorldDataBaseA6
// AUTHOR:  Timothy Lee
// DESCRIPTION:  Performs and Queries involving getting data from the database.  
// *************************************************************************************

using System;
using System.IO;

using System.Data;                          
using MySql.Data;                            
using MySql.Data.MySqlClient;                

namespace WorldDataBaseA6
{
    class DataRetrieval
    {
        // -----------------------------------------------------------------------------
        // Since the query could return MANY rows of the table:
        //      - a DataReader object is used with the ExecuteReader method
        //      - a loop is used to go through the multi-row result set
        //          (A pre-test while loop is used since potentially there could be
        //              0 rows returned).
        // NOTE:  rdr.Read method returns 2 columns' values, as specified in the
        //      SELECT statement: Name & Population.  These are returned in rdr's
        //      array locations [0] and [1].  If needed, the rdr array also has a
        //      "length" property, rdr.FieldCount, which is 2, which could be used
        //      to control a loop.
        // -----------------------------------------------------------------------------
        public static void DoQueryWhichGetsMultRows(MySqlConnection conn,                //returns multiple rows in a query
                            StreamWriter file, string sql, int transNum)
        {
            file.WriteLine();
            file.WriteLine("\r\nSQL ({0}): {1}", transNum, sql);
            file.WriteLine();

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.VisibleFieldCount; i++)
                    {
                        file.Write("{0,-14}: ", rdr[i]);
                    }
                    file.WriteLine();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                file.WriteLine("\r\nERROR on {0}, QUERY not done", transNum);
                file.WriteLine(ex.ToString());
            }
        }


        // -----------------------------------------------------------------------------
        public static void DoQueryWhichGetsSingleValue(MySqlConnection conn,              // gets query with a single value
                            StreamWriter file, string sql, int transNum)
        {
            file.WriteLine("\r\nSQL ({0}): {1}", transNum, sql);

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int number = Convert.ToInt32(result);
                    file.WriteLine("\r\n{0} countries in the World database", number);
                }
            }
            catch (Exception ex)
            {
                file.WriteLine("\r\nERROR on {0}, QUERY not done", transNum);
                file.WriteLine(ex.ToString());
                Console.WriteLine("ERROR on {0}, QUERY not done", transNum);
            }
        }


        public static void DoQueryToCheckUpdate(MySqlConnection conn,                    //  A  query to check if update
                            StreamWriter file, string sql, int transNum)
        {
            file.WriteLine("\r\nSQL ({0}): {1}", transNum, sql);

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                object result = cmd.ExecuteScalar();
                file.WriteLine("\r\nNEW Head of USA is {0}", result);
            }
            catch (Exception ex)
            {
                file.WriteLine("\r\nERROR on {0}, QUERY not done", transNum);
                file.WriteLine(ex.ToString());
            }
        }


        // -----------------------------------------------------------------------------
        // This query could return ONE row at most since the WHERE condition specifies a
        // "candidate key" (a field which uniquely identifies a row) (although the DB
        // schema didn't specify this when the DB was created - it should have!).
        // So 0 or 1 row could be return, no more.
        // -----------------------------------------------------------------------------
        public static void DoQueryOnCK(MySqlConnection conn,
                            StreamWriter file, string sql, int transNum)
        {
            file.WriteLine("\r\nSQL ({0}): {1}", transNum, sql);

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();

                // NOTE:  rdr returned ALL columns as specified in the SELECT *.
                //      These are returned in array locations rdr[0] through rdr[14].
                //      That's hardcoded here, but rdr.FieldCount could've been used.

                for (int i = 0; i < rdr.VisibleFieldCount; i++)
                {
                    file.Write("{0,-14}: ", rdr[i]);
                }
                file.WriteLine();

                rdr.Close();
            }
            catch (Exception ex)
            {
                file.WriteLine("\r\nERROR on {0}, QUERY not done", transNum);
                file.WriteLine(ex.ToString());
            }
        }
    }
}
