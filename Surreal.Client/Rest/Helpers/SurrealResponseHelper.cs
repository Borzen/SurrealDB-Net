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

            var resultData = JsonConvert.DeserializeObject<List<SurrealModel<T>>>(response.Content).FirstOrDefault();

            SurrealDBResult<T> result = new SurrealDBResult<T>()
            {
                Error = "",
                IsSuccessful = true,
                Result = resultData.Result.FirstOrDefault()
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
                Results = JsonConvert.DeserializeObject<List<SurrealModel<T>>>(response.Content).FirstOrDefault()?.Result
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
            return JsonConvert.DeserializeObject<List<SurrealModel<T>>>(response.Content).FirstOrDefault();
        }

        private static (bool,string) ResponseErrorChecking(RestResponse response)
        {

            if (!response.IsSuccessful)
            {
                return (false, response.ErrorMessage);
            }

            var surrealModel = JsonConvert.DeserializeObject<List<SurrealResponse>>(response.Content);

            if (surrealModel[0].Status != "OK")
            {
                //TODO: Better Error handling
                return (false, "Error Happened");
            }
            
            return (true, "");
        }
    }
}
