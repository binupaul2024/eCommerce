using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoryContract
{
    public interface IUserRepository
    {
        /// <summary>
        /// Method to add a new user to the database. and Return the added user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);


        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);


    }
}
