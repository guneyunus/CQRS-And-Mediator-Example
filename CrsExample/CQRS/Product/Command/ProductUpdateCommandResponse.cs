using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductUpdateCommandResponse
    {
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }
    }
}
