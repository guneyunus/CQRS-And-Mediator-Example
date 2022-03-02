using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductDeleteCommandRequest : IRequest<ProductDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
