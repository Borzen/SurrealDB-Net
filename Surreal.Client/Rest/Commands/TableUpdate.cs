﻿using Newtonsoft.Json;
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
    internal class TableUpdate
    {
        public static SurrealDBResult<T> TableUpdateRecord<T>(string tableName, string id, T data, RestClient client)
        {
            string endpoint = string.Format(EndpointConstants.TableId, tableName, id);
            string dataJson = JsonConvert.SerializeObject(data);
            RestRequest request = new RestRequest(endpoint);
            request.AddJsonBody(dataJson);
            RestResponse response = RestSharpTaskRunner.RunRestSharpPatch(client,request);
            bool isSuccessful = response.IsSuccessful;
            string error = "";
            if (isSuccessful) 
            {
                //TODO: Better error handling
                error = "An error happened";
            }
            SurrealDBResult<T> surrealDBResult = new SurrealDBResult<T>()
            {
                Error = error,
                IsSuccessful = isSuccessful,
                Result = isSuccessful ? JsonConvert.DeserializeObject<T>(response.Content) : default(T)
            };
            return surrealDBResult;
        }
    }
}
