using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstEfCoreApp
{
    public static class Commands
    {
      public static void ListAll()
      {
        using (var db = new AppDbContext())
        {
          var books = db.Books.AsNoTracking().Include(a => a.Author);
          foreach (var book in books)
          {
            var webUrl = book.Author.WebUrl == null
              ? "- no web URL given -"
              : book.Author.WebUrl;
            Console.WriteLine($"{book.Title} by {book.Author.Name}");
            Console.WriteLine("     " +
              "Published on " +
              $"{book.PublishedOn:dd-MMMM-yyyy}" +
              $". {webUrl}");
          }
        }
      }

      public static void ChangeWebUrl()
      {
        
      }
    }
}
