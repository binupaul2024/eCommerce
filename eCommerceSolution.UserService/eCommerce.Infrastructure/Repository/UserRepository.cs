
using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DBContext;

namespace eCommerce.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDBContext _dbContext;

        public UserRepository(DapperDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            string Query = "INSERT INTO public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";

           int rowCountAffected =  await _dbContext.DbConnection.ExecuteAsync(Query, user);
            
            if(rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }                
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {

            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

            var parameters = new { Email = email, Password = password };

            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
            
            return user;

            //return new ApplicationUser
            //{
            //    UserID = Guid.NewGuid(),
            //    Email = email,
            //    Password = password,
            //    PersonName = "Test User",
            //    Gender = GenderOption.Male.ToString()
            //};
        }
    }
}
