using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstEfCoreApp
{
    public class AppDbContext : DbContext
    {
      private const string ConnectionString = @"Server=localhost;Database=ConsoleBooks;Trusted_Connection=True;";
      
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
        optionsBuilder.UseSqlServer(ConnectionString);
      }
      
      public DbSet<Book> Books { get; set; }
    }
}
