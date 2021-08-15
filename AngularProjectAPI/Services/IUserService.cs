using AngularProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
