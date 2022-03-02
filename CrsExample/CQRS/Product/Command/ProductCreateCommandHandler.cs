using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CqrsExample.Dal;
using MediatR;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommandRequest, ProductCreateCommandResponse>
    {
        private readonly MyContext _context;
        public ProductCreateCommandHandler(MyContext context)
        {
            _context = context;
        }
        public Task<ProductCreateCommandResponse> Handle(ProductCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Entitiy.Product()
            {
                Description = request.Description,
                Name = request.Name,
                Price = request.Price
            };

            _context.Products.Add(product);
            
            var control = _context.SaveChanges();
            
            if (control == 0)
            {
                var response = new ProductCreateCommandResponse()
                {
                    Message = "Urun Kaydederken Hata oluştu",
                    IsSucceeded = false
                };
                 return Task.FromResult(response);
            }


            var responseTwo = new ProductCreateCommandResponse()
            {
                Message = "Urun Kaydı başarıyla gerçekleşti",
                IsSucceeded = true
            };
            return Task.FromResult(responseTwo);
        }
    }
}
