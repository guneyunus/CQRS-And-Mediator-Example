using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CqrsExample.CQRS.Product.Query
{
    public class ProductGetAllQueryRequest : IRequest<ProductGetAllQueryResponse>
    {

    }
}
