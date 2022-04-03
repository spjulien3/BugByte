using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class AccountControllerTests : IntegrationTests
    {
        

        [TestMethod]
        public async Task GetAllUsersTask()
        {


            var response = await TestClient.GetAsync("/api/users");

           response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}