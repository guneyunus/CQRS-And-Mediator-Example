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
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQueryRequest, ProductGetAllQueryResponse>
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public ProductGetAllQueryHandler(IMapper mapper,MyContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<ProductGetAllQueryResponse> Handle(ProductGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var ProductList = _context.Products.ToList().Select(x => _mapper.Map<ProductGetByIdQueryResponse>(x)).ToList();

            var response = new ProductGetAllQueryResponse() {Products = ProductList};
            return Task.FromResult(response);
        }
    }
}
