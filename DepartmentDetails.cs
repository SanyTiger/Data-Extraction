using System;

namespace DataExtractionFromTextFile
{
    public partial class DBCommunication
    {
        public void department()
        {
            try
            {
                // Call function to connect to the MySQL DB.
                connectDB();

                // Call function to retrieve the department's details from txt file located in FileSystem.
                var lstValues = getValuesList(departmentFilePathName);

                foreach (var objValues in lstValues)
                {
                    // Call function to remove the single quotes within the data values of the txt file.
                    var stringValuesSplit = removeQuotesAndCommas(objValues);

                    // INSERT Statement
                    var sqlCmd = conn.CreateCommand();
                    sqlCmd.CommandText = "INSERT INTO department(Dnumber, Dname, Mgr_ssn, Mgr_start_date)"
                                        + " VALUES(@Dnumber, @Dname, @Mgr_ssn, @Mgr_start_date)";

                    sqlCmd.Parameters.AddWithValue("@Dnumber", Convert.ToInt32(stringValuesSplit[1]));
                    sqlCmd.Parameters.AddWithValue("@Dname", stringValuesSplit[0]);
                    sqlCmd.Parameters.AddWithValue("@Mgr_ssn", stringValuesSplit[2]);
                    sqlCmd.Parameters.AddWithValue("@Mgr_start_date", stringValuesSplit[3]);
                    sqlCmd.ExecuteNonQuery();
                }

                // Close the MySQL DB connection
                conn.Close();
            }
            // Close the MySQL DB connection
            catch (Exception ex)
            { conn.Close(); }
        }
    }
}
