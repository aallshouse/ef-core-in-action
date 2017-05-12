using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

      public static void ChangeWebUrl(int entityId)
      {
        using(var db = new AppDbContext())
        {
          var book = db.Books
            .Include(a => a.Author)
            .Single(b => b.BookId == entityId);
          Console.Write($"{book.Title} > ");
          var newWebUrl = Console.ReadLine();
          book.Author.WebUrl = newWebUrl;
          db.SaveChanges();
          Console.WriteLine("... SaveChanges called.");
        }
        ListAll();
      }
    }
}
