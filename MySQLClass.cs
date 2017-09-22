using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataExtractionFromTextFile
{
    [TestClass]
    public class MySQLClass
    {
        [TestMethod]
        public void InsertDepartmentValues()
        {
            var dbComm = new DBCommunication();
            dbComm.department();
        }
        [TestMethod]
        public void InsertEmployeeValues()
        {
            var dbComm = new DBCommunication();
            dbComm.employee();
        }
        [TestMethod]
        public void InsertDepartmentLocationValues()
        {
            var dbComm = new DBCommunication();
            dbComm.departmentLocation();
        }
        [TestMethod]
        public void InsertProjectValues()
        {
            var dbComm = new DBCommunication();
            dbComm.project();
        }
        [TestMethod]
        public void InsertWorksOnValues()
        {
            var dbComm = new DBCommunication();
            dbComm.worksOn();
        }
    }
}
