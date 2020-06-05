using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingSysApi.Models;

namespace TestingSysApi.Contexts
{
    public class QuestionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
            .UseSqlite(@"Data Source = TestingSys.db;");
        }

        public DbSet<Question> Question { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
            new Question() { Id = 1, question = "What's the capital of France?", answer1 = "Paris", answer2 = "Rome", answer3 = "London", answer4 = "Berlin", true_answer = 1 },
            new Question() { Id = 2, question = "What's the capital of Italy?", answer1 = "Paris", answer2 = "Rome", answer3 = "London", answer4 = "Berlin", true_answer = 2 }
            );
        }
    }
}
