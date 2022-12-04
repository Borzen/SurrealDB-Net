using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Models
{
    internal class SurrealResponse
    {
        public string Time { get; set; }
        public string Status { get; set; }
        public List<dynamic> Result { get; set; }
    }
}
