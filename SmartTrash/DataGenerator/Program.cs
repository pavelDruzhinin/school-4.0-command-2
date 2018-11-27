using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.CommandLine;
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
                .AddCommandLine(args)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TrashContext>()
                .UseSqlServer(config.GetConnectionString("TrashContext"));

            double timeFactor = config.GetValue<double>("tf", 1.0F);
            string choosedFillStrategy = config.GetValue<string>("fill", "simplerandom");
            IVolumeFillStrategy fillStrategy = new RandomFillVolume();

            // Add new strategies here 
            if (choosedFillStrategy == "ontime")
            {
                fillStrategy = new OnTimeBasedFillVolume();
            }

            using (var context = new TrashContext(optionsBuilder.Options))
            {
                var faker = new DataFaker(context, fillStrategy);
                faker.TimeFactor = timeFactor;
                faker.Run();
            }
        }
    }
}
