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
    public class ProductReadRepository : GenericReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
