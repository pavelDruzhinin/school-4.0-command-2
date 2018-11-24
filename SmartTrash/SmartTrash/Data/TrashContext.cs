using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartTrash.Data.Mappings;
using SmartTrash.Models;

namespace SmartTrash.Data
{
    public class TrashContext : DbContext
    {
        public TrashContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WasteCollectionArea> WasteCollectionAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new WasteCollectionAreaMap());
        }
    }
}
