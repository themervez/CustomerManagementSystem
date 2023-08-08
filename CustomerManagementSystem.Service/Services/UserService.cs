using AutoMapper.Internal.Mappers;
using CustomerManagementSystem.Core.DTOs;
using CustomerManagementSystem.Core.Entities;
using CustomerManagementSystem.Core.Services;
using CustomerManagementSystem.Service.Mapper;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto)//For new user
        {
            var user = new AppUser { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)//İf there is an error like duplicated e-mail etc.
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<AppUserDto>.Fail(new ErrorDto(errors, true), 400);//400: client error
            }
            return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
        }

        public async Task<Response<AppUserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<AppUserDto>.Fail("UserName not found", 404, true);
            }

            return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
        }
    }
}
