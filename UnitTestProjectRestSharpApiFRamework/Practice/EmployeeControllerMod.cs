using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using UnitTestProjectRestSharpApiFRamework.POCO_Class_RmgYantra;

namespace UnitTestProjectRestSharpApiFRamework.Practice

{
    [TestClass]
    [TestCategory("Practice")]
    public class EmployeeControllerMod
    {
        internal string url = "http://localhost:8084/projects";

        [TestMethod]
        [TestCategory("Practice")]
        public void GetEmployees()
        {
            RestClient client = new RestClient(url);
            var request = new RestRequest(Method.GET);// working exactly
            var output = client.Execute(request);
            Console.WriteLine(output.Content);

        }
        [TestMethod]
        [TestCategory("Practice")]
        public void GetEmployee()
        {
            RestClient client = new RestClient(url);
            var request = new RestRequest("{abhishek}", Method.GET);
            // var request = new RestRequest("studentmanagementportal", Method.GET);
            request.AddUrlSegment("abhishek", "abhishek"); //not working
            var output = client.Execute(request);
            Console.WriteLine(output.Content);
        }
        [TestMethod]
        [TestCategory("Practice")]
        public void GetEmployeeById()
        {
            // string url = "http://localhost:8084/employees";
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("/TY_PROJ_202", Method.GET);     //working by commenting this string url in this method
            var output = client.Execute(request);
            Console.WriteLine(output.Content);
            Assert.AreEqual(HttpStatusCode.OK, output.StatusCode);

            }
        [TestMethod]
        [TestCategory("Practice")]
        public void PostEmployee()
        {
           string url = "http://localhost:8084/employees";
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(new Employee()
            {
                email = "abhishek@gmail.com",
                designation = "SeniorTestEngineer",
                experience = 4.3,
                empName = "abhishek",
                mobileNo = "8109941382",
                project = "RmgYantra",
                role = "TestLead"
            });
            var output = client.Execute(request);
            Console.WriteLine(output.Content);
            Console.WriteLine(output.StatusCode);
            //conflict because we are using same data to store
           Assert.AreEqual(HttpStatusCode.Created, output.StatusCode);
        }
        [TestMethod]
        [TestCategory("Practice")]
        public void GetEmployeeByName()
        {
            RestClient client = new RestClient(url);
            //  RestRequest request = new RestRequest("s/varun1", Method.GET);
            RestRequest request = new RestRequest("abhishek", Method.GET);
            var output = client.Execute(request);
            Console.WriteLine(output.Content);
            Assert.AreEqual(HttpStatusCode.OK, output.StatusCode);
        }
        [TestMethod]
        [TestCategory("Practice")]
        public void DeleteByEmpId() 
        {
            RestClient client = new RestClient(url + 's');
            RestRequest request = new RestRequest("TY_PROJ_203", Method.DELETE);
            var output = client.Execute(request);
            Console.WriteLine(output.Content);
            Assert.AreEqual(HttpStatusCode.NoContent, output.StatusCode);
        }

    }
    } 
