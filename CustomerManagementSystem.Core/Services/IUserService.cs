using CustomerManagementSystem.Core.DTOs;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Core.Services
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);//for saving users to the database

        Task<Response<AppUserDto>> GetUserByNameAsync(string userName);//To get information that according to the UserName
    }
}
