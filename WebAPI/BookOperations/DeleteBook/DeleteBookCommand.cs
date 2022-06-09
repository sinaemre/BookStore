using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı!");
            
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}