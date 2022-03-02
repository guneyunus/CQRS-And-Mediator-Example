using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CqrsExample.Dal;
using MediatR;

namespace CqrsExample.CQRS.Product.Query
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQueryRequest, ProductGetByIdQueryResponse>
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public ProductGetByIdQueryHandler(IMapper mapper, MyContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<ProductGetByIdQueryResponse> Handle(ProductGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);
            
            if (product == null)
            {
                return null;
            }

            var response = _mapper.Map<ProductGetByIdQueryResponse>(product);

            return Task.FromResult(response);
        }
    }
}
