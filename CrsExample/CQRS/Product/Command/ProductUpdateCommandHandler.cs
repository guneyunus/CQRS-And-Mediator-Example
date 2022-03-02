using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CqrsExample.Dal;
using MediatR;

namespace CqrsExample.CQRS.Product.Command
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommandRequest, ProductUpdateCommandResponse>
    {
        private readonly MyContext _myContext;

        public ProductUpdateCommandHandler(MyContext context)
        {
            _myContext = context;
        }

        public Task<ProductUpdateCommandResponse> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _myContext.Products.FirstOrDefault(x => x.Id == request.Id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            _myContext.Products.Update(product);
            var responseControl =  _myContext.SaveChanges();

            if (responseControl == 0)
                return null;

            var response = new ProductUpdateCommandResponse()
            {
                IsSucceeded = true,
                Message = "Ürün başarlı bir şekilde güncellendi"
            };
            return Task.FromResult(response);
        }
    }
}
