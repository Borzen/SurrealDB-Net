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
            restClient.AddDefaultHeader("Accept", "application/json");
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

        public List<T> ExecuteSqlQuery<T>(string sql)
        {
            return SQLPost.RunSurrealSQLPost<T>(sql, restClient);
        }

        public SurrealDBResults<T> GetTableRecords<T>(string tableName)
        {
            return TableGet.TableGetHandler<T>(tableName, restClient);
        }

        public SurrealDBResult<T> GetTableRecord<T>(string tableName, string id)
        {
            var surrealResults = TableGet.TableGetHandler<T>(tableName, restClient, id);

            return new SurrealDBResult<T>() {
                IsSuccessful = surrealResults.IsSuccessful,
                Error= surrealResults.Error,
                Result = surrealResults.Results.FirstOrDefault()
            };
        }

        public SurrealDBResult<T> UpdateRecord<T>(string tableName, string id, T data)
        {
            return TableUpdate.TableUpdateRecord(tableName, id, data, restClient);
        }
    }
}
