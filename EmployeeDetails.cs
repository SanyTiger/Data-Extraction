using System;

namespace DataExtractionFromTextFile
{
    public partial class DBCommunication
    {
        public void employee()
        {
            try
            {
                // Call function to connect to the MySQL DB.
                connectDB();

                // Call function to retrieve the employee's details from txt file located in FileSystem.
                var lstValues = getValuesList(employeeFilePathName);

                foreach (var objValues in lstValues)
                {
                    // Call function to remove the single quotes within the data values of the txt file.
                    var stringValuesSplit = removeQuotesAndCommas(objValues);

                    // INSERT Statement
                    var sqlCmd = conn.CreateCommand();
                    sqlCmd.CommandText = "INSERT INTO employee(Fname, Minit, Lname, Ssn, Bdate, Address, Sex, Salary, Super_ssn, Dno)"
                                        + " VALUES(@Fname, @Minit, @Lname, @Ssn, @Bdate, @Address, @Sex, @Salary, @Super_ssn, @Dno)";

                    sqlCmd.Parameters.AddWithValue("@Fname", stringValuesSplit[0]);
                    sqlCmd.Parameters.AddWithValue("@Minit", stringValuesSplit[1]);
                    sqlCmd.Parameters.AddWithValue("@Lname", stringValuesSplit[2]);
                    sqlCmd.Parameters.AddWithValue("@Ssn", stringValuesSplit[3]);
                    sqlCmd.Parameters.AddWithValue("@Bdate", stringValuesSplit[4]);
                    sqlCmd.Parameters.AddWithValue("@Address", stringValuesSplit[5]);
                    sqlCmd.Parameters.AddWithValue("@Sex", stringValuesSplit[6]);
                    sqlCmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(stringValuesSplit[7]));
                    sqlCmd.Parameters.AddWithValue("@Super_ssn", stringValuesSplit[8] == "null" ? null : stringValuesSplit[8]);
                    sqlCmd.Parameters.AddWithValue("@Dno", Convert.ToInt32(stringValuesSplit[9]));
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
