using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServiceContract;



namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;
            }


           return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true, Token = "token1" };

            //return new AuthenticationResponse
            //(
            //     user.UserID,
            //    user.Email,
            //    user.PersonName,
            //    "tocken1",
            //    user.Gender,
            //    true

            //);

        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {

            //ApplicationUser? user =  await _mapper.Map<ApplicationUser>(RegisterRequest);

            ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);

            ApplicationUser? registeredUser = await _userRepository.AddUser(user);

            //ApplicationUser? user = await _userRepository.AddUser(new ApplicationUser
            //{
            //    Email = registerRequest.Email,
            //    PersonName = registerRequest.PersonName,
            //    Password = registerRequest.Password,
            //    Gender = registerRequest.Gender.ToString()
            //});



            if (registeredUser == null)
            {
                return null;
            }


            return _mapper.Map<AuthenticationResponse>(registeredUser) with { Sucess = true, Token = "token" };

            //return new AuthenticationResponse
            //(
            //     user.UserID,
            //    user.Email,
            //    user.PersonName,
            //    user.Gender,
            //    "token",
            //    true
            //);
        }
    }
}
