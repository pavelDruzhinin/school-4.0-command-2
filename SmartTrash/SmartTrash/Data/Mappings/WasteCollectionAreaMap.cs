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

            builder.HasData(
                new WasteCollectionArea() { Id = 1, Name = "Мусорная площадка 1", Latitude = 61.790867F, Longitude = 34.367756F, Volume = 1100, FilledVolume = 136 },
                new WasteCollectionArea() { Id = 2, Name = "Мусорная площадка 2", Latitude = 61.789527F, Longitude = 34.370004F, Volume = 1100, FilledVolume = 541 },
                new WasteCollectionArea() { Id = 3, Name = "Мусорная площадка 3", Latitude = 61.790118F, Longitude = 34.373194F, Volume = 1100, FilledVolume = 748 },
                new WasteCollectionArea() { Id = 4, Name = "Мусорная площадка 4", Latitude = 61.801895F, Longitude = 34.344477F, Volume = 1100, FilledVolume = 134 },
                new WasteCollectionArea() { Id = 5, Name = "Мусорная площадка 5", Latitude = 61.806393F, Longitude = 34.331806F, Volume = 1100, FilledVolume = 814 },
                new WasteCollectionArea() { Id = 6, Name = "Мусорная площадка 6", Latitude = 61.801088F, Longitude = 34.324629F, Volume = 1100, FilledVolume = 4 },
                new WasteCollectionArea() { Id = 7, Name = "Мусорная площадка 7", Latitude = 61.798635F, Longitude = 34.324017F, Volume = 1100, FilledVolume = 34 },
                new WasteCollectionArea() { Id = 8, Name = "Мусорная площадка 8", Latitude = 61.796797F, Longitude = 34.333040F, Volume = 1100, FilledVolume = 74 },
                new WasteCollectionArea() { Id = 9, Name = "Мусорная площадка 9", Latitude = 61.793501F, Longitude = 34.341280F, Volume = 1100, FilledVolume = 434 },
                new WasteCollectionArea() { Id = 10, Name = "Мусорная площадка 10", Latitude = 61.790222F, Longitude = 34.341728F, Volume = 1100, FilledVolume = 237 },
                new WasteCollectionArea() { Id = 11, Name = "Мусорная площадка 11", Latitude = 61.786890F, Longitude = 34.347671F, Volume = 1100, FilledVolume = 321 },
                new WasteCollectionArea() { Id = 12, Name = "Мусорная площадка 12", Latitude = 61.785336F, Longitude = 34.349356F, Volume = 1100, FilledVolume = 432 },
                new WasteCollectionArea() { Id = 13, Name = "Мусорная площадка 13", Latitude = 61.786209F, Longitude = 34.355160F, Volume = 1100, FilledVolume = 36 },
                new WasteCollectionArea() { Id = 14, Name = "Мусорная площадка 14", Latitude = 61.786946F, Longitude = 34.360664F, Volume = 1100, FilledVolume = 267 },
                new WasteCollectionArea() { Id = 15, Name = "Мусорная площадка 15", Latitude = 61.788447F, Longitude = 34.366857F, Volume = 1100, FilledVolume = 103 },
                new WasteCollectionArea() { Id = 16, Name = "Мусорная площадка 16", Latitude = 61.788193F, Longitude = 34.372715F, Volume = 1100, FilledVolume = 365 },
                new WasteCollectionArea() { Id = 17, Name = "Мусорная площадка 17", Latitude = 61.789646F, Longitude = 34.374324F, Volume = 1100, FilledVolume = 178 },
                new WasteCollectionArea() { Id = 18, Name = "Мусорная площадка 18", Latitude = 61.790880F, Longitude = 34.378616F, Volume = 1100, FilledVolume = 613 },
                new WasteCollectionArea() { Id = 19, Name = "Мусорная площадка 19", Latitude = 61.792871F, Longitude = 34.374893F, Volume = 1100, FilledVolume = 345 },
                new WasteCollectionArea() { Id = 20, Name = "Мусорная площадка 20", Latitude = 61.803728F, Longitude = 34.340808F, Volume = 1100, FilledVolume = 197 }
            );
        }
    }
}
