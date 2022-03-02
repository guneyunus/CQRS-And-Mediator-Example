using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductDeleteCommandResponse
    {
        public bool isSuccees { get; set; }
        public string Message { get; set; }

    }
}
