using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar bulunmadı!");

            author.BookId = Model.BookId != default ? Model.BookId : author.BookId;

            author.Name = Model.Name != default ? Model.Name : author.Name;

            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;

            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BookId { get; set; }
    }
}
