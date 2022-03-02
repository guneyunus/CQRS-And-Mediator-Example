using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductUpdateCommandRequest : IRequest<ProductUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
