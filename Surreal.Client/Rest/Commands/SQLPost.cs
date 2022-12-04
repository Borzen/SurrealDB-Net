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
    public class SQLPost
    {
        internal static SurrealModel<T> RunSurrealSQLPost<T>(string surrealQL, RestClient client)
        {
            RestRequest request = new RestRequest(EndpointConstants.SQL);
            request.AddBody(surrealQL);
            RestResponse response = RestSharpTaskRunner.RunRestSharpPost(client, request);
            if (!response.IsSuccessful)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<SurrealModel<T>>(response.Content);
        }
    }
}
