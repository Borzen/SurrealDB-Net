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
        internal static SurrealDBResults<T> TableGetHandler<T>(string tableName, RestClient client, string id = "")
        {
            string endpoint = id == "" ? string.Format(EndpointConstants.Table, tableName) : string.Format(EndpointConstants.TableId, tableName, id);
            RestRequest request = new RestRequest(endpoint);
            SurrealResponseHelper.GetAllSurrealDBResults<T>(RestSharpTaskRunner.RunRestSharpGet(client, request));
            return SurrealResponseHelper.GetAllSurrealDBResults<T>(RestSharpTaskRunner.RunRestSharpGet(client, request)); ;
        }
    }
}
