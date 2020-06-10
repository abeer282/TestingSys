using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingSysApi.Models;

namespace TestingSysApi.Contexts
{
    public class WorkerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
            .UseSqlite(@"Data Source = TestingSys.db;");
        }

        public DbSet<Worker> Worker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker { Id = 6, fname="Bob", lname="Green", email="bob@green.com" , did_test=false, pass_test=false }
            );
        }
    }
}
