using DirectoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly string DataSource = "person.db";
        public DbSet<Person> People { get; set; }

        //For SqLite Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DataSource}");
        }
    }
}