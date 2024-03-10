using Core.Application.Interfaces.Repositories.Products;
using Core.Application.Interfaces.UnitOfWorks;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWorks
    {
        private ApplicationDbContext _context;

        private IProductReadRepository _productReadRepository;
        private IProductWriteRepository _ProductWriteRepository;

        public UnitOfWork(ApplicationDbContext context, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _context = context;
            _productReadRepository = productReadRepository;
            _ProductWriteRepository = productWriteRepository;
        }

        public IProductReadRepository ProductRead
        {
            get { return _productReadRepository; }
        }

        public IProductWriteRepository ProductWrite
        {
            get { return _ProductWriteRepository; }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
