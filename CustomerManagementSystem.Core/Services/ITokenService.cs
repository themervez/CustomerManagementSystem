using CustomerManagementSystem.Core.Configuration;
using CustomerManagementSystem.Core.DTOs;
using CustomerManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}
