using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Applications.AuthorOperations.Queries.GetByIdAuthor
{
    public class GetByIdAuthorQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorViewModel Handle()
        {
            var author = _context.Authors.Include(x => x.Book).FirstOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı!");

            AuthorViewModel vm = _mapper.Map<AuthorViewModel>(author);
            return vm;
        }


    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Book { get; set; }
    }
}
