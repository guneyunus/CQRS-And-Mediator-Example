using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsExample.Abstractions.Interfaces;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductCreateCommandResponse:IResponseObject
    {
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }
    }
}
