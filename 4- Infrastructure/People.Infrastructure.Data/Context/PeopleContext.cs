using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using People.Domain.Models;
using People.Infrastructure.Data.Extensions;
using People.Infrastructure.Data.Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace People.Infrastructure.Data.Context
{
    public class PeopleContext : DbContext
    {

        public DbSet<PersonModel> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PersonMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
