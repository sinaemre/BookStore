using AutoMapper;
using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı!");

            if (author.BookId > 0)
                throw new InvalidOperationException("Yazar silinemez.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
