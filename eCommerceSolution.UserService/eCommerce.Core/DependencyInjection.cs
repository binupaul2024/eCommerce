using eCommerce.Core.ServiceContract;
using eCommerce.Core.Services;
using eCommerce.Core.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
 

namespace eCommerce.Core
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
        public static IServiceCollection AddCore(this IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();

            service.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            return service;
        }
    }
}
