using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSurrealClientTests.Models;
using Surreal.Client.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Rest.Tests
{
    [TestClass()]
    public class SurrealRestClientTests
    {
        [TestMethod()]
        public void ExecuteSqlQueryTest()
        {
            string serverSqlCreateStatement = "CREATE account SET name = 'ACME Inc', created_at = time::now();";
            string surrealHostLocation = "http://localhost:8000";
            string NS = "test";
            string DB = "test";
            string username = "root";
            string password = "root";

            SurrealRestClient surrealClient = new SurrealRestClient(surrealHostLocation, username, password, DB, NS);

            var a = surrealClient.ExecuteSqlQuery<AccountModel>(serverSqlCreateStatement);

            Assert.IsTrue(a != null);
        }
    }
}