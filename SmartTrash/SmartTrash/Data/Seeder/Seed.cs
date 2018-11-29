using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SmartTrash.Models.IdentityModels;

namespace SmartTrash.Data.Seeder
{
    public class Seed
    {
        private readonly TrashContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(TrashContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedMaps()
        {
            //if (!_context.WasteCollectionAreas.Any())
            //{
            //    _context.SaveChanges();
            //}
        }

        public void SeedUsers()
        {
            if (!_context.Users.Any())
            {
                var roles = new List<Role>
                {
                    new Role {Name = "Manager"},
                    new Role {Name = "Admin"}
                };

                if (!_context.Roles.Any())
                    foreach (var role in roles)
                    {
                        _roleManager.CreateAsync(role).Wait();
                    }

                var adminUser = new User
                {
                    UserName = "Admin",
                    Email = "admin@localhost.localdomain"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "1234567890").Result;

                if (result.Succeeded)
                {
                    var createdUser = _userManager.FindByNameAsync("Admin").Result;
                    _userManager.AddToRolesAsync(createdUser, new string[] {"Admin", "Manager"}).Wait();
                }

                //var usersData = System.IO.File.ReadAllText("Data/InitData/Users.json");
                //var users = JsonConvert.DeserializeObject<List<User>>(usersData);

                //foreach (var user in users)
                //{
                //    _userManager.CreateAsync(user, "1234567890").Wait();
                //}

            }
        }
    }
}
