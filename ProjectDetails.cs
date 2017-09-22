using System;

namespace DataExtractionFromTextFile
{
    public partial class DBCommunication
    {
        public void project()
        {
            try
            {
                // Call function to connect to the MySQL DB.
                connectDB();

                // Call function to retrieve the project's details from txt file located in FileSystem.
                var lstValues = getValuesList(projectFilePathName);
                foreach (var objValues in lstValues)
                {
                    // Call function to remove the single quotes within the data values of the txt file.
                    var stringValuesSplit = removeQuotesAndCommas(objValues);

                    // INSERT Statement
                    var sqlCmd = conn.CreateCommand();
                    sqlCmd.CommandText = "INSERT INTO project(Pname, Pnumber, Plocation, Dnum)"
                                        + " VALUES(@Pname, @Pnumber, @Plocation, @Dnum)";

                    sqlCmd.Parameters.AddWithValue("@Pname", stringValuesSplit[0]);
                    sqlCmd.Parameters.AddWithValue("@Pnumber", Convert.ToInt32(stringValuesSplit[1]));
                    sqlCmd.Parameters.AddWithValue("@Plocation", stringValuesSplit[2]);
                    sqlCmd.Parameters.AddWithValue("@Dnum", Convert.ToInt32(stringValuesSplit[3]));
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
