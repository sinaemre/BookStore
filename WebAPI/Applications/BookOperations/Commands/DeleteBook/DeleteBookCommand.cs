using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId;
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == BookId);
            var author = _context.Authors.FirstOrDefault(x => x.BookId == book.Id);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı!");
            
            _context.Books.Remove(book);
            author.BookId = 0;
            _context.SaveChanges();
        }
    }
}