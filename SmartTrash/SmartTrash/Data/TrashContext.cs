using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartTrash.Data.Mappings;
using SmartTrash.Models;
using SmartTrash.Models.IdentityModels;

namespace SmartTrash.Data
{
    public class TrashContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public TrashContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WasteCollectionArea> WasteCollectionAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new WasteCollectionAreaMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }
    }
}
