using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectRestSharpApiFRamework.Practice
{
    [TestClass]
    public  class DataBaseUtil
    {
        OdbcCommand command;

        [TestMethod, TestCategory("Employee")]
        public void odbc()
        {

            string connectionString = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            Console.WriteLine(connection.ConnectionString);//printing the connection string
            Console.WriteLine(connection.ConnectionTimeout);//printing the timout of connection (by default it is 15 sec)
            Console.WriteLine(connection.Database);//printing the database connection
            Console.WriteLine(connection.Driver);//printing the driver
            Console.WriteLine(connection.ServerVersion);//printing the server version
            string query = "select * from project";

            OdbcCommand command = new OdbcCommand(query, connection);
            var response = command.ExecuteReader();
            while (response.Read())

            {
                //project table of rmgyantra has 5 columns (printing the 5 columns data)
                Console.WriteLine(response[0] + " " + response[1] + " " + response[2] + " " + response[3] + " " + response[4] + " " + response[5]);
            }
        }
    }
}
