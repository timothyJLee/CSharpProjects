// CLASS:  StringHandling      used by PROGRAM:  WorldDataBaseA6
// AUTHOR:  Timothy Lee
// DESCRIPTION:  Performs basic string manipulation of transInput to make sure it is 
//               properly formatted and working SQL statements
// *************************************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldDataBaseA6
{
    class StringHandling
    {
        private string s1;
        private char transCode;
        private string tableName;
        private string colNames;   
        private string dataValues;

        public string String1 { get; set; }
        public char TransactionCode { get; set; }
        public string TableName { get; set; }
        public string ColumnNames { get; set; }
        public string DataValues { get; set; }
        public string SQLQueryString { get; set; }


        public StringHandling()
        {
            s1 = "";
            transCode = '\0';
            tableName = "";
            colNames = "";
            dataValues = "";
            SQLQueryString = "";
        }


        public void SubDivideString(string s)
        {
            s1 = s;
            transCode = s[0];

            switch (transCode)
            {
                case 'S':
                    Select();
                    break;
                case 'I':
                    Insert();
                    break;
                case 'D':
                    Delete();
                    break;
                case 'U':
                    Update();
                    break;
            }
        }

        private void Select()
        {
            SQLQueryString = s1;  // basically Finished sqlQuery
            SetPublicValues();
        }

        private void Insert()
        {
            string[] field = new string[3];
            field = s1.Split('|');

            tableName = field[0].Substring(2, field[0].Length - 2);

            if (field.Length == 2)
            {
                colNames = "";
                dataValues = field[1];
            }
            else
            {
                colNames = field[1];
                dataValues = field[2];
            }

            if (colNames == "")
            {
                SQLQueryString = "INSERT INTO " + tableName + " VALUES (" + dataValues + ")";  // Finished sqlQuery
            }
            else
            {
                SQLQueryString = "INSERT INTO " + tableName + " (" + colNames + ") VALUES (" + dataValues + ")";  // Finished sqlQuery
            }

            SetPublicValues();
        }

        private void Delete()
        {
            string[] field = new string[3];
            field = s1.Split('|');

            tableName = field[0].Substring(2, field[0].Length - 2);

            if (field.Length == 2)
            {
                colNames = "";
                dataValues = field[1];
            }
            else
            {
                colNames = field[1];
                dataValues = field[2];
            }

            SQLQueryString = "DELETE FROM " + tableName + " WHERE " + colNames + " = " + dataValues;  // Finished sqlQuery
            SetPublicValues();
        }

        private void Update()
        {
            SQLQueryString = s1;  // Already Finished sqlQuery
            SetPublicValues();
        }

        private void SetPublicValues()
        {
            String1 = s1;
            TransactionCode = transCode;
            TableName = tableName;
            ColumnNames = colNames;
            DataValues = dataValues;
        }
    }
}


