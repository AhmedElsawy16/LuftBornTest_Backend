using Core.Application.Interfaces.Repositories.Products;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.Products
{
    public class ProductWriteRepository : GenericWriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
