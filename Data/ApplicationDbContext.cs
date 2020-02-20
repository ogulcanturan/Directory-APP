using DirectoryAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryAPP.Data
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly string DataSource = "person.db";
        public DbSet<Person> People { get; set; }

        //For SQLITE Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DataSource}");
        }
    }
}
