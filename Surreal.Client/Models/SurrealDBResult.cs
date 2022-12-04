﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surreal.Client.Models
{
    public class SurrealDBResult<T>
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public T Result { get; set; }
    }

    public class SurrealDBResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
    }
}