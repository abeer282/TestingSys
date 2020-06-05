using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingSysApi.Models;

namespace TestingSysApi.Contexts
{
    public class TestContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
            .UseSqlite(@"Data Source = TestingSys.db;");
        }

        public DbSet<Test> Test { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().HasData(
                new Test { Id = 1, number_of_questions = 3, questions = "1#2#3#", has_time = true, time_in_seconds = 600 , can_review = false , time_of_review = 0 , is_choice_random = true , can_move_back = true , pass_questions_number =2 , answers = "" }
            );
        }
    }
}
