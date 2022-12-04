using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Models
{
    internal class SurrealModel<T> 
    {
        public string Time { get; set; }
        public string Status { get; set; }
        public T Result { get; set; }
    }
}
