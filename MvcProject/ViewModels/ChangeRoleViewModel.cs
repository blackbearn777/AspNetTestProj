using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MvcProject.ViewModels
{
    public class ChangeRoleViewModel
    {
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }

        public List<IdentityRole> AllRoles { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}