using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServiceContract;



namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;
            }


            return new AuthenticationResponse
            (
                 user.UserID,
                user.Email,
                user.PersonName,
                "tocken1",
                user.Gender,
                true

            );

        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser? user = await _userRepository.AddUser(new ApplicationUser
            {
                Email = registerRequest.Email,
                PersonName = registerRequest.PersonName,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString()
            });

            if (user == null)
            {
                return null;
            }

            return new AuthenticationResponse
            (
                 user.UserID,
                user.Email,
                user.PersonName,
                user.Gender,
                "token",
                true
            );
        }
    }
}
