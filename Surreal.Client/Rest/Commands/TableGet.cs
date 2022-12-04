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
    public class TableGet
    {
        internal static List<SurrealModel<T>> TableGetAll<T>(string tableName, RestClient client)
        {
            string endpoint = string.Format(EndpointConstants.Table, tableName);
            RestRequest request = new RestRequest(endpoint);
            RestResponse response = RestSharpTaskRunner.RunRestSharpGet(client,request);
            if(!response.IsSuccessful) 
            {
                return default;
            }

            return JsonConvert.DeserializeObject<List<SurrealModel<T>>>(response.Content);
        }
        internal static SurrealModel<T> TableGetSingle<T>(string tableName, string id, RestClient client)
        {
            string endpoint = string.Format(EndpointConstants.TableId, tableName, id);
            RestRequest request = new RestRequest(endpoint);
            RestResponse response = RestSharpTaskRunner.RunRestSharpGet(client, request);
            if (!response.IsSuccessful)
                return default;
            return JsonConvert.DeserializeObject<SurrealModel<T>>(response.Content);
        }
    }
}
