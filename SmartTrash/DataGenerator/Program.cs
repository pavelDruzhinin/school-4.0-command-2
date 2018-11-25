using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Collections.Generic;
using SmartTrash.Data;
using SmartTrash.Models;

namespace DataGenerator
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TrashContext>()
                .UseSqlServer(config.GetConnectionString("TrashContext"));

            using (var context = new TrashContext(optionsBuilder.Options))
            {
                context.Add(new WasteCollectionArea()
                    {
                        Name = "Мусорная площадка 1",
                        Longitude = 61.790867F,
                        Latitude = 34.367756F,
                        Volume = 1100,
                        FilledVolume = 136
                    });

                context.SaveChanges();
            }
        }
    }
}
