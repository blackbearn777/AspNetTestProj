using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models.Interfaces
{
    interface IUserValidator<TUser> where TUser:class
    {
        Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user);
    }
}
