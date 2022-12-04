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
        internal static List<T> RunSurrealSQLPost<T>(string surrealQL, RestClient client)
        {
            RestRequest request = new RestRequest(EndpointConstants.SQL);
            request.AddBody(surrealQL);
            var resultData = SurrealResponseHelper.GetSQLSurrealDBResult<T>(RestSharpTaskRunner.RunRestSharpPost(client, request));
            return resultData.Result;
        }
    }
}
