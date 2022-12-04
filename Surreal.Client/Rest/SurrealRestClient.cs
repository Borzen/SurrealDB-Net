using RestSharp;
using RestSharp.Authenticators;
using Surreal.Client.Interfaces;
using Surreal.Client.Models;
using Surreal.Client.Rest.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Rest
{
    public class SurrealRestClient : ISurrealClient
    {
        private readonly RestClient restClient;

        public SurrealRestClient(string surrealEndpoint, string surrealUsername, string surrealPassword, string surrealDb, string surrealNamespace)
        {

            restClient = new RestClient(surrealEndpoint)
            {
                Authenticator = new HttpBasicAuthenticator(surrealUsername, surrealPassword)
            };
            restClient.AddDefaultHeader("NS", surrealNamespace);
            restClient.AddDefaultHeader("DB", surrealDb);
        }

        public SurrealDBResult<T> CreateRecord<T>(string tableName, T data)
        {
            return TableCreate.TableCreateRecord(tableName, data, restClient);
        }

        public SurrealDBResult<T> CreateRecord<T>(string tableName, string id, T data)
        {
            return TableCreate.TableCreateRecord(tableName, id, data, restClient);
        }

        public SurrealDBResult DeleteAllTableRecords(string tableName)
        {
            return TableDelete.DeleteAllRecords(tableName, restClient);
        }

        public SurrealDBResult DeleteRecord(string tableName, string id)
        {
            return TableDelete.DeleteSingleRecord(tableName, id, restClient);
        }

        public T ExecuteSqlQuery<T>(string sql)
        {
            var surrealData = SQLPost.RunSurrealSQLPost<T>(sql, restClient);
            if (surrealData == default)
                return default;
            return surrealData.Result;
        }

        public List<T> GetTableRecords<T>(string tableName)
        {
            List<T> returnData = new List<T>();
            var surrealData = TableGet.TableGetAll<T>(tableName, restClient);
            foreach(var data in surrealData)
            {
                returnData.Add(data.Result);
            }
            return returnData;
        }

        public T GetTableRecord<T>(string tableName, string id)
        {
            var surrealData = TableGet.TableGetSingle<T>(tableName, id, restClient);
            if (surrealData == default)
                return default;
            return surrealData.Result;
        }

        public SurrealDBResult<T> UpdateRecord<T>(string tableName, string id, T data)
        {
            return TableUpdate.TableUpdateRecord(tableName, id, data, restClient);
        }
    }
}
