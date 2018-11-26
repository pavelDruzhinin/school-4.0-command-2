using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Collections.Generic;
using SmartTrash.Data;
using SmartTrash.Models;

namespace Faker
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
                var faker = new DataFaker(context, new RandomNewVolume());
                faker.TimeFactor = 600.0F;
                faker.Run();
            }
        }
    }
}
