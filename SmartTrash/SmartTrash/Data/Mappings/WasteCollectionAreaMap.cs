using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTrash.Models;

namespace SmartTrash.Data.Mappings
{
    public class WasteCollectionAreaMap : IEntityTypeConfiguration<WasteCollectionArea>
    {
        public void Configure(EntityTypeBuilder<WasteCollectionArea> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasData(
            //    new WasteCollectionArea() { Id = 1, Name = "Мусорная площадка 1", Longitude = 61.790867F, Latitude = 34.367756F, Volume = 1100, FilledVolume = 136},
            //    new WasteCollectionArea() { Id = 2, Name = "Мусорная площадка 2", Longitude = 61.789527F, Latitude = 34.370004F, Volume = 1100, FilledVolume = 541},
            //    new WasteCollectionArea() { Id = 3, Name = "Мусорная площадка 3", Longitude = 61.790118F, Latitude = 34.373194F, Volume = 1100, FilledVolume = 748}
            //);
        }
    }
}
