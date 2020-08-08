using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.ViewModels.System.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<List<RoleViewModel>> GetAll()
        {
            var roles = await roleManager.Roles
                .Select(x => new RoleViewModel()
                {
                    RoleID = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return roles;
        }
    }
}