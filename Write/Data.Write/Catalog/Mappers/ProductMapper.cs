using System;
using System.Collections.Generic;
using System.Text;
using Data.Write.Catalog.Entities;
using Domain.Catalog;

namespace Data.Write.Catalog.Mappers
{
    public class ProductMapper : AutoMapper.Profile
    {
        public ProductMapper()
        {
            //Map: Domain -> Data

            /*CreateMap<Product, ProductEntity>()
                .ForMember(x => x.Foo, x => x.MapFrom(m => m.Id));*/
        }
    }
}
