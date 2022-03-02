using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CqrsExample.Dal;
using MediatR;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommandRequest, ProductDeleteCommandResponse>
    {
        private readonly MyContext _context;

        public ProductDeleteCommandHandler(MyContext context)
        {
            _context = context;
        }
        public Task<ProductDeleteCommandResponse> Handle(ProductDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            _context.Products.Remove(product);
            var responseCOntrol = _context.SaveChanges();

            if (responseCOntrol == 0)
            {
                return null;
            }

            var response = new ProductDeleteCommandResponse()
            {
                isSuccees = true,
                Message = "ürün başarıyla silindi"
            };
            return Task.FromResult(response);
        }
    }
}
