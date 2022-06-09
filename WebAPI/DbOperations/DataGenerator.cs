using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.DbOperations
{
    public class DataGenerator 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;

                context.AddRange(
                    new Book
                    {
                        Title = "Lean Startup", //Personal Growth
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    
                    new Book
                    {
                        Title = "Herland", //Science Fiction
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23)
                    },
                    
                    new Book
                    {
                        Title = "Dune", //Science Fiction
                        GenreId = 1,
                        PageCount = 540,
                        PublishDate = new DateTime(2002,01,12)
                    }
                );
                context.SaveChanges();
            }

        }
    }
}