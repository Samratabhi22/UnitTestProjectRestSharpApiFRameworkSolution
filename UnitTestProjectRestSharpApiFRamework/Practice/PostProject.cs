using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectRestSharpApiFRamework.generic;
using UnitTestProjectRestSharpApiFRamework.POCO_Class_RmgYantra;

namespace UnitTestProjectRestSharpApiFRamework.Practice
{
    public class PostProject: BaseClass
    {
        [TestMethod]
        [TestCategory("Practice")]
        public void PostProjectTest()
        {
            RestSharpUtils rt = new RestSharpUtils();

            Project p = new Project();
            Status status = new Status();
            var body = p.ProjectBody("nextLevel", status.created);
            var response = rt.Post(endPoints.addProject, body);
            Console.WriteLine(response.Content);
        }
    }
}
