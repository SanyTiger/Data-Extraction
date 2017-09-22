using System;

namespace DataExtractionFromTextFile
{
    public partial class DBCommunication
    {
        public void worksOn()
        {
            try
            {
                // Call function to connect to the MySQL DB.
                connectDB();

                // Call function to retrieve the works on details from txt file located in FileSystem.
                var lstValues = getValuesList(worksOnFilePathName);
                foreach (var objValues in lstValues)
                {
                    // Call function to remove the single quotes within the data values of the txt file.
                    var stringValuesSplit = removeQuotesAndCommas(objValues);

                    // INSERT Statement
                    var sqlCmd = conn.CreateCommand();
                    sqlCmd.CommandText = "INSERT INTO works_on(Essn, Pno, Hours)"
                                        + " VALUES(@Essn, @Pno, @Hours)";

                    sqlCmd.Parameters.AddWithValue("@Essn", stringValuesSplit[0]);
                    sqlCmd.Parameters.AddWithValue("@Pno", Convert.ToInt32(stringValuesSplit[1]));
                    sqlCmd.Parameters.AddWithValue("@Hours", Convert.ToDecimal(stringValuesSplit[2]));
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
