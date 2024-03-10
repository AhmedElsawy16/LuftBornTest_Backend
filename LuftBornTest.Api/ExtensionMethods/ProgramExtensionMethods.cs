using Core.Application.Interfaces.Repositories;
using Core.Application.Interfaces.Repositories.Products;
using Core.Application.Interfaces.UnitOfWorks;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repositories.Products;
using Infrastructure.Persistence.UnitOfWorks;

namespace LuftBornTest.Api.ExtensionMethods
{
    public static class ProgramExtensionMethods
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
            services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));

            services.AddScoped(typeof(IUnitOfWorks), typeof(UnitOfWork));

            services.AddScoped(typeof(IProductReadRepository), typeof(ProductReadRepository));
            services.AddScoped(typeof(IProductWriteRepository), typeof(ProductWriteRepository));
        }
    }
}
