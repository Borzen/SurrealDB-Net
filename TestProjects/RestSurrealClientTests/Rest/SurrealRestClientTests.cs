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
        string surrealHostLocation = "http://localhost:8000";
        string NS = "test";
        string DB = "test";
        string username = "root";
        string password = "root";

        string tableName = "account";

        [TestMethod()]
        public void ExecuteSqlQueryTest()
        {
            string serverSqlCreateStatement = "CREATE account SET name = 'ACME Inc', created_at = time::now();";

            SurrealRestClient surrealClient = new SurrealRestClient(surrealHostLocation, username, password, DB, NS);

            var sqlResult = surrealClient.ExecuteSqlQuery<AccountModel>(serverSqlCreateStatement);

            Assert.IsTrue(sqlResult != null);
        }

        [TestMethod()]
        public void CreateRecordTest()
        {
            AccountModel accountTestDataWithoutId = new AccountModel()
            {
                CreatedAt = DateTime.Now,
                Name = "Testing Record Creation Endpoint"
            };

            SurrealRestClient surrealRestClient = new SurrealRestClient(surrealHostLocation, username, password, DB, NS);

            var insertResult = surrealRestClient.CreateRecord<AccountModel>(tableName, accountTestDataWithoutId);

            Assert.IsTrue(insertResult.IsSuccessful);

        }

        [TestMethod()]
        public void UpdateRecordTest()
        {
            SurrealRestClient surrealRestClient = new SurrealRestClient(surrealHostLocation, username, password, DB, NS);

            var allAccountTableData = surrealRestClient.GetTableRecords<AccountModel>(tableName);

            if (!allAccountTableData.IsSuccessful)
                Assert.Fail();

            if (allAccountTableData.Results.Count == 0)
                Assert.Inconclusive();

            var testRecord = allAccountTableData.Results.First();
            testRecord.Name = "Update Test";

            var updateRecord = surrealRestClient.UpdateRecord(tableName, testRecord.Id.Replace(tableName + ":", ""), testRecord);

            Assert.IsTrue(updateRecord.IsSuccessful);
        }

        [TestMethod()]
        public void GetTableRecordTest()
        {

            AccountModel accountTestDataWithoutId = new AccountModel()
            {
                CreatedAt = DateTime.Now,
                Name = "Testing Single Record Endpoint",
            };

            SurrealRestClient surrealClient = new SurrealRestClient(surrealHostLocation, username, password, DB, NS);

            var insertWithIdResult = surrealClient.CreateRecord<AccountModel>(tableName, "123456", accountTestDataWithoutId);

            if (!insertWithIdResult.IsSuccessful)
                Assert.Fail();

            var getSingleRecord = surrealClient.GetTableRecord<AccountModel>(tableName, "123456");

            Assert.IsTrue(getSingleRecord.IsSuccessful);
        }

        [TestMethod()]
        public void DeleteRecordTest()
        {
            SurrealRestClient surrealClient = new SurrealRestClient(surrealHostLocation, username, password, DB, NS);

            var result = surrealClient.DeleteRecord(tableName, "123456");

            Assert.IsTrue(result.IsSuccessful);
        }

        [TestMethod()]
        public void DeleteAllTableRecordsTest()
        {
            SurrealRestClient surrealClient = new SurrealRestClient(surrealHostLocation, username, password, DB, NS);

            var result = surrealClient.DeleteAllTableRecords(tableName);

            Assert.IsTrue(result.IsSuccessful);
        }
    }
}