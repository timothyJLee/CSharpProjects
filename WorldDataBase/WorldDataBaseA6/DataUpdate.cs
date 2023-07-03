// CLASS:  DataUpdate      used by PROGRAM:  WorldDataBaseA6
// AUTHOR:  Timothy Lee
// DESCRIPTION: Class to handle all updates of the database.  Can perform Deletes and 
//              Inserts and will handle anything that involves changing the data of the 
//              Database...
// *************************************************************************************

using System;
using System.IO;

using System.Data;                           
using MySql.Data;                           
using MySql.Data.MySqlClient;             

namespace WorldDataBaseA6
{
    class DataUpdate
    {

        public static void DoInsert(MySqlConnection conn, StreamWriter file, string sql, int transNum, StringHandling s)
        {
            file.WriteLine("\r\nSQL ({0}): {1}", transNum, sql);

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                cmd.ExecuteNonQuery();
                file.WriteLine("\r\nOK, INSERT of " + s.DataValues + " was done");
            }
            catch (Exception ex)
            {
                file.WriteLine("\r\nERROR on {0}, INSERT not done", transNum);
                file.WriteLine(ex.ToString());
            }
        }

        public static void DoUpdate(MySqlConnection conn, StreamWriter file, string sql, int transNum, StringHandling s)
        {
            file.WriteLine("\r\nSQL ({0}): {1}", transNum, sql);

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                cmd.ExecuteNonQuery();
                file.WriteLine("\r\nOK, UPDATE of " + s.DataValues + "'s HeadOfState done");
            }
            catch (Exception ex)
            {
                file.WriteLine("\r\nERROR on {0}, UPDATE not done", transNum);
                file.WriteLine(ex.ToString());
                Console.WriteLine("ERROR on {0}, UPDATE not done", transNum);
            }
        }
        // -----------------------------------------------------------------------------
        public static void DoDelete(MySqlConnection conn, StreamWriter file, string sql, int transNum, StringHandling s)
        {
            file.WriteLine("\r\nSQL ({0}): {1}", transNum, sql);

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                cmd.ExecuteNonQuery();
                file.WriteLine("\r\nOK, DELETE of " + s.DataValues + " was done");
            }
            catch (Exception ex)
            {
                file.WriteLine("\r\nERROR on {0}, DELETE not done", transNum);
                file.WriteLine(ex.ToString());
            }
        }
        // -----------------------------------------------------------------------------
    }
}
