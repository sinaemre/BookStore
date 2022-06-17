using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Entities;

namespace WebAPI.DbOperations
{
    public class DataGenerator 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any() || context.Authors.Any() || context.Genres.Any())
                    return;
                
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth",
                    },
                    new Genre
                    {
                        Name = "Science Fiction",
                    },
                    new Genre
                    {
                        Name = "Romance",
                    }


                );

                context.AddRange(
                  new Author
                  {
                      Name = "Charlotte Perkins",
                      Surname = "Gilman",
                      Birthday = new DateTime(1860, 07, 03),
                      BookId = 1
                  },
                  new Author
                  {
                      Name = "Frank",
                      Surname = "Herbert",
                      Birthday = new DateTime(1920, 10, 08),
                      BookId = 3
                  },
                  new Author
                  {
                      Name = "Eric",
                      Surname = "Ries",
                      Birthday = new DateTime(1978, 09, 22),
                      BookId = 2
                  }
                );

                context.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12),
                        AuthorId = 3
                    },
                    
                    new Book
                    {
                        Title = "Herland", 
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23),
                        AuthorId = 1
                    },
                    
                    new Book
                    {
                        Title = "Dune", 
                        GenreId = 1,
                        PageCount = 540,
                        PublishDate = new DateTime(2002,01,12),
                        AuthorId = 2
                    }
                );

              

                
                context.SaveChanges();
            }

        }
    }
}