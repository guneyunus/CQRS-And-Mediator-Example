using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsExample.CQRS.Product.Query
{
    public class ProductGetAllQueryResponse
    {
        public List<ProductGetByIdQueryResponse>  Products { get; set; }
    }
}
