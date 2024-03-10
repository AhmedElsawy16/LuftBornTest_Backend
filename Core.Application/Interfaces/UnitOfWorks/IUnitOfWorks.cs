using Core.Application.Interfaces.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        IProductReadRepository ProductRead { get; }
        IProductWriteRepository ProductWrite { get; }

        Task<int> SaveAsync();
    }
}
