using AutoMapper;
using CustomerManagementSystem.Core.DTOs;
using CustomerManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Service.Mapper
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<AppUserDto, AppUser>().ReverseMap();
        }
    }
}
