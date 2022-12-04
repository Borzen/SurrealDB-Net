using Newtonsoft.Json;
using RestSharp;
using Surreal.Client.Models;
using Surreal.Client.Rest.Constants;
using Surreal.Client.Rest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Rest.Commands
{
    internal class TableDelete
    {
        internal static SurrealDBResult DeleteAllRecords(string tableName, RestClient client)
        {
            string endpoint = string.Format(EndpointConstants.Table, tableName);
            return HandleCommand(endpoint, client);
        }
        internal static SurrealDBResult DeleteSingleRecord(string tableName, string id, RestClient client)
        {
            string endpoint = string.Format(EndpointConstants.TableId,tableName,id);
            return HandleCommand(endpoint, client);
        }
        private static SurrealDBResult HandleCommand(string endpoint, RestClient client)
        {
            RestRequest request = new RestRequest(endpoint);
            RestResponse response = RestSharpTaskRunner.RunRestSharpDelete(client, request);
            bool isSuccessful = response.IsSuccessful;
            string error = "";
            if (!response.IsSuccessful)
            {
                //TODO: Better error handling
                error = "error happened";
            }
            SurrealDBResult sdbResult = new SurrealDBResult()
            {
                IsSuccessful = isSuccessful,
                Error = error,
            };
            return sdbResult;
        }
    }
}
