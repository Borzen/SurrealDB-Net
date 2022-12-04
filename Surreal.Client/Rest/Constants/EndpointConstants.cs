using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Rest.Constants
{
    internal class EndpointConstants
    {
        public const string SQL = "/sql";
        public const string Table = "/key/{0}";
        public const string TableId = Table + "/{1}";
    }
}
