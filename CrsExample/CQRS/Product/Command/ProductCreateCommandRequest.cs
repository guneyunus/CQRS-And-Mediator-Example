using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductCreateCommandRequest :IRequest<ProductCreateCommandResponse>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

    }
}
