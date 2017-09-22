using System;
using System.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataExtractionFromTextFile
{
    public partial class DBCommunication
    {
        MySqlConnection conn;

        //MySQL connection details
        string password = "PasswordHere";
        string username = "UsernameHere";
        string serverName = "ServerNameHere";
        string databaseName = "DatabaseNameHere";

        // Location of the files given containing the data values for insert
        string worksOnFilePathName = "C:\FakePath\WORKS_ON.txt";
        string employeeFilePathName = "C:\FakePath\EMPLOYEE.txt";
        string projectFilePathName = "C:\FakePath\PROJECT.txt";
        string departmentFilePathName = "C:\FakePath\DEPARTMENT.txt";
        string departmentLocationFilePathName = "C:\FakePath\DEPT_LOCATIONS.txt";

        /// <summary>
        /// Connecting to the MySQL DB
        /// </summary>
        public void connectDB()
        {
            try
            {
                conn = new MySqlConnection("server=" + serverName + "; uid=" + username + "; pwd=" + password + "; database=" + databaseName + "; ");
                conn.Open();
            }
            // Close the MySQL DB connection
            catch (MySqlException ex)
            { conn.Close(); }
        }

        /// <summary>
        /// Fetching the necesarry file containing the data values.
        /// </summary>
        /// <param name="filePathName"></param>
        /// <returns></returns>
        public List<string> getValuesList(string filePathName)
        {
            string readText = File.ReadAllText(filePathName);
            return readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        }

        /// <summary>
        /// Removing additional quotes introduced in the values fetched
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public string[] removeQuotesAndCommas(string strValue)
        {
            var rm = strValue.Replace("'", "").Replace("\"", "");
            return Regex.Split(rm, ", ");
        }
    }
}
