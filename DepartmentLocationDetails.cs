using System;

namespace DataExtractionFromTextFile
{
    public partial class DBCommunication
    {
        public void departmentLocation()
        {
            try
            {
                // Call function to connect to the MySQL DB.
                connectDB();

                // Call function to retrieve the department location details from txt file located in FileSystem.
                var lstValues = getValuesList(departmentLocationFilePathName);
                foreach (var objValues in lstValues)
                {
                    // Call function to remove the single quotes within the data values of the txt file.
                    var stringValuesSplit = removeQuotesAndCommas(objValues);

                    // INSERT Statement
                    var sqlCmd = conn.CreateCommand();
                    sqlCmd.CommandText = "INSERT INTO dept_locations(Dnumber, Dlocation)"
                                        + " VALUES(@Dnumber, @Dlocation)";

                    sqlCmd.Parameters.AddWithValue("@Dnumber", Convert.ToInt32(stringValuesSplit[0]));
                    sqlCmd.Parameters.AddWithValue("@Dlocation", stringValuesSplit[1]);
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
