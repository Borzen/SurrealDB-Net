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
    internal class TableCreate
    {
        internal static SurrealDBResult<T> TableCreateRecord<T>(string tableName, T data, RestClient client)
        {
            string endpoint = string.Format(EndpointConstants.Table, tableName);
            return HandleCommand<T>(endpoint, data, client);
        }

        internal static SurrealDBResult<T> TableCreateRecord<T>(string tablename, string id, T data, RestClient client)
        {
            string endpoint = string.Format(EndpointConstants.TableId, tablename, id);
            return HandleCommand<T> (endpoint, data, client);
        }

        private static SurrealDBResult<T> HandleCommand<T>(string endpoint, T data, RestClient client)
        {
            string recordJson = JsonConvert.SerializeObject(data);
            RestRequest request = new RestRequest(endpoint);
            request.AddJsonBody(recordJson);
            return SurrealResponseHelper.GetSingleSurrealDBResult<T>(RestSharpTaskRunner.RunRestSharpPost(client,request));
        }
    }
}
