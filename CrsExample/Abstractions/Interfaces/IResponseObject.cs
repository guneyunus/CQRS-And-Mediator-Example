using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsExample.Abstractions.Interfaces
{
    interface IResponseObject
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
    }
}
