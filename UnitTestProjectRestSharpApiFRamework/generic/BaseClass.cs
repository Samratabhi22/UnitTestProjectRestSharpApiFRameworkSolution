﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectRestSharpApiFRamework.Generic;

namespace UnitTestProjectRestSharpApiFRamework.generic
{
    public class BaseClass
    {
        public static TestContext testContext;
        public string dataBaseConnection = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
        public static OdbcConnection odbcConnection;
        public ExcelUtility excelUtility;
        public ODBCValidation oDBCValidation;
        public RestSharpUtils restSharpUtils;
        public CSharpUtilitys cSharpUtilitys;
        public EndPoints endPoints;

        [AssemblyInitialize]
        public static void AssemblyInilization(TestContext context)
        {
            Console.WriteLine("hi");
        }

        [ClassInitialize]
        public static void DataBase(TestContext context)
        {

        }

        [TestInitialize]
        public void OpeningDataBase()
        {

        }

        [TestCleanup]
        public void ClosingDataBase()
        {
        }
    }
}
