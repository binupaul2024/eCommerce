using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContract
{
    public interface IUserService
    {
        /// <summary>
        /// Method to authenticate a user. It takes a LoginRequest object as input and returns an AuthenticationResponse object if the authentication is successful, or null if it fails.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        /// <summary>
        /// Method to register a new user. It takes a RegisterRequest object as input and returns an AuthenticationResponse object if the registration is successful, or null if it fails.
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
