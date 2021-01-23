using BreederBlazor.Models;
using BreederBlazor.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Services.Auth
{
    public interface IAuthService
    {
        User user { get; set; }

        Task<string> Register(string login, string password);

        Task Login(string login, string password);
    }
}
