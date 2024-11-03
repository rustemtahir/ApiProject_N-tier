using ApiDers.Core.Entities;
using ApiDers.Core.Repositories.Abstractions;
using APIDers1.Data.Context;
using APIDers1.Data.Repositories.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Data.Concrets
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
