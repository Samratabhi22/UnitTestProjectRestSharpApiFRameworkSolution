﻿using Bytescout.Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectRestSharpApiFRamework.Generic;
using UnitTestProjectRestSharpApiFRamework.POCO_Class_RmgYantra;

namespace UnitTestProjectRestSharpApiFRamework.Resources
{
   
        [TestClass]
        public class Data
        {
            static Employee employ;

            public static IEnumerable<object[]> Employee()
            {
                CSharpUtilitys cSharpUtilitys = new CSharpUtilitys();
                int value = cSharpUtilitys.RandomInt();
                string userName = "varun" + value;
                string designation = "Automation Test Engineer";
                double experience = 4.1;
                string empName = "varu1n";
                string email = "varu1nsn9@gmail.com";
                string username = userName;
                string project = "Unitte";
                string role = "ROLE_EMPLOYEE";
                string mobileNo = "9845632103";

                yield return new object[] { designation, experience, empName, email, username, project, role, mobileNo };
            }

            [TestMethod]
            public static IEnumerable<object[]> exceldata()
            {
                Spreadsheet spreadsheet = new Spreadsheet();
                spreadsheet.LoadFromFile("C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx");
                var sheet = spreadsheet.Workbook.Worksheets["DATA"];
                var maxROW = sheet.UsedRangeRowMax;
                var maxcol = sheet.UsedRangeColumnMax;


                for (int i = 1; i < maxROW; i++)
                {
                    string designation = sheet.Cell(i, 0).ToString();
                    string experience = sheet.Cell(i, 1).ToString();
                    string empName = sheet.Cell(i, 2).ToString();
                    string email = sheet.Cell(i, 3).ToString();
                    string username = sheet.Cell(i, 4).ToString();
                    string project = sheet.Cell(i, 5).ToString();
                    string role = sheet.Cell(i, 6).ToString();
                    string mobileNo = sheet.Cell(i, 7).ToString();
                    // yield return new object[] { designation, experience, empName, email, username, project, role, mobileNo };


                    employ = new Employee
                    {
                        designation = designation,
                        empName = empName,
                        email = email,
                        username = username,
                        project = project,
                        role = role,
                        mobileNo = mobileNo
                    };

                    var a = employ;

                    yield return new object[] { a };

                }
            }

            [TestMethod]
            [TestCategory("DataFetching")]
            public void dataExcelStoring()
            {
                Data data = new Data();
                data.EmployeeId();
                data.ProjectId();
            }


            public void EmployeeId()
            {
                Spreadsheet spreadsheet = new Spreadsheet();
                string excelpath = "C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx";
                spreadsheet.LoadFromFile("C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx");
                var sheet = spreadsheet.Workbook.Worksheets["EMPLOYEEID"];
                string value = "";
                string connectionString = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
                OdbcConnection odbcConnection = new OdbcConnection(connectionString);
                odbcConnection.Open();
                string query = "select emp_id from employee";
                OdbcCommand odbcCommand = new OdbcCommand(query, odbcConnection);
                var response = odbcCommand.ExecuteReader();
                int i = 1;
                while (response.Read())
                {
                    Console.WriteLine(response[0]);
                    sheet.Cell(i, 0).Value = response[0].ToString();
                    i++;
                    spreadsheet.SaveAs(excelpath);

                }
                spreadsheet.Close();
            }

            public void ProjectId()
            {
                Spreadsheet spreadsheet = new Spreadsheet();
                string excelpath = "C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx";
                spreadsheet.LoadFromFile("C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx");
                var sheet = spreadsheet.Workbook.Worksheets["PROJECTID"];
                string connectionString = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
                OdbcConnection odbcConnection = new OdbcConnection(connectionString);
                odbcConnection.Open();
                string query = "select project_id from project";
                OdbcCommand odbcCommand = new OdbcCommand(query, odbcConnection);
                var response = odbcCommand.ExecuteReader();
                int i = 1;
                while (response.Read())
                {
                    Console.WriteLine(response[0]);
                    sheet.Cell(i, 0).Value = response[0].ToString();
                    i++;
                    spreadsheet.SaveAs(excelpath);

                }
                spreadsheet.Close();
            }
        }
}
