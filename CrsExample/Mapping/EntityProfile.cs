using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CqrsExample.CQRS.Product.Query;
using CqrsExample.Entitiy;
using CqrsExample.Models;

namespace CqrsExample.Mapping
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Product, VMProduct>();
            CreateMap<Product, ProductGetByIdQueryResponse>();

        }
    }
}
