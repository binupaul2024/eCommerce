using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DBContext;
using eCommerce.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
 

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the service collection. 
        /// This method will register all necessary services, such as database contexts, repositories, 
        /// and other infrastructure-related services, to the dependency injection container.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection service) {

            service.AddSingleton<IUserRepository, UserRepository>();
            service.AddTransient<DapperDBContext>();
            return service;
        }
    }
}
