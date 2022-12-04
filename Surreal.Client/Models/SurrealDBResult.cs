using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Models
{
    public class SurrealDBResult<T> : SurrealDBResult
    {
        public T Result { get; set; }
    }

    public class SurrealDBResults<T> : SurrealDBResult
    {
        public List<T> Results { get; set; }
    }

    public class SurrealDBResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
    }
}
