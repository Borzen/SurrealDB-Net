using Newtonsoft.Json;
using RestSharp;
using Surreal.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Rest.Helpers
{
    internal class SurrealResponseHelper
    {
        internal static SurrealDBResult<T> GetSingleSurrealDBResult<T> (RestResponse response)
        {

            (bool, string) isSuccessful = ResponseErrorChecking(response);

            if (!isSuccessful.Item1)
            {
                return new SurrealDBResult<T>()
                {
                    Error = isSuccessful.Item2,
                    IsSuccessful = false,
                    Result = default
                };
            }


            SurrealDBResult<T> result = new SurrealDBResult<T>()
            {
                Error = "",
                IsSuccessful = true,
                Result = JsonConvert.DeserializeObject<SurrealModel<T>>(response.Content).Result.FirstOrDefault()
            };
            return result;
        }

        internal static SurrealDBResults<T> GetAllSurrealDBResults<T> (RestResponse response)
        {
            (bool, string) isSuccessful = ResponseErrorChecking(response);

            if(!isSuccessful.Item1)
            {
                return new SurrealDBResults<T>()
                {
                    Error = isSuccessful.Item2,
                    IsSuccessful = false,
                    Results = default,
                };
            }

            SurrealDBResults<T> result = new SurrealDBResults<T>()
            {
                Error = "",
                IsSuccessful = true,
                Results = JsonConvert.DeserializeObject<SurrealModel<T>>(response.Content).Result
            };
            return result;

        }
        internal static SurrealModel<T> GetSQLSurrealDBResult<T> (RestResponse response)
        {
            (bool, string) isSuccessful = ResponseErrorChecking(response);

            if (!isSuccessful.Item1)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<SurrealModel<T>>(response.Content);
        }

        private static (bool,string) ResponseErrorChecking(RestResponse response)
        {

            if (!response.IsSuccessful)
            {
                return (false, response.ErrorMessage);
            }

            var surrealModel = JsonConvert.DeserializeObject<SurrealResponse>(response.Content);

            if (surrealModel.Status != "OK")
            {
                //TODO: Better Error handling
                return (false, "Error Happened");
            }
            
            return (true, "");
        }
    }
}
