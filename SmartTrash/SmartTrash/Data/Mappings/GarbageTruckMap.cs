using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTrash.Models;

namespace SmartTrash.Data.Mappings
{
    public class GarbageTruckMap : IEntityTypeConfiguration<GarbageTruck>
    {
        public void Configure(EntityTypeBuilder<GarbageTruck> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasAlternateKey(t => t.NumberPlate).HasName("AlternateKey_NumberPlate");
            builder.Property(t => t.Volume).IsRequired();
            builder.Property(t => t.MaintananceCostFactor).IsRequired();
            //builder.Property(t => t.NumberPlate).IsRequired().HasMaxLength(8);

            builder.HasData(
                new GarbageTruck() { Id = 1, NumberPlate = "B546OP10", Model = "Камаз-65115 КО-440В1", Volume = (decimal)(18000 * 4.75), MaintananceCostFactor = 15 },
                new GarbageTruck() { Id = 2, NumberPlate = "M182AK10", Model = "Камаз-65115 КО-440-5", Volume = (decimal)(18000 * 2.75), MaintananceCostFactor = 15 },
                new GarbageTruck() { Id = 3, NumberPlate = "O334XT10", Model = "Камаз-5325 КО-440В2", Volume = (decimal)(17000 * 4.75), MaintananceCostFactor = 13 },
                new GarbageTruck() { Id = 4, NumberPlate = "K937ET10", Model = "Маз-4380 КО-440-4М", Volume = (decimal)(11000 * 2.75), MaintananceCostFactor = 10 }
            );
        }
    }
}
