using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Rest.Helpers
{
    //TODO: This needs to be really converted into a real Task Runner for REST endpoints. 
    internal class RestSharpTaskRunner
    {
        internal static Func<RestClient, RestRequest, RestResponse> RunRestSharpPost = (client, request) =>
        {
            return client.Post(request);
        };

        internal static Func<RestClient, RestRequest, RestResponse> RunRestSharpGet = (client, request) =>
        {
            return client.Get(request);
        };

        internal static Func<RestClient, RestRequest, RestResponse> RunRestSharpDelete = (client, request) =>
        {
            return client.Delete(request);
        };

        internal static Func<RestClient, RestRequest, RestResponse> RunRestSharpPut = (client, request) =>
        {
            return client.Put(request);
        };

        internal static Func<RestClient, RestRequest, RestResponse> RunRestSharpPatch = (client, request) =>
        {
            return client.Patch(request);
        };
    }
}
