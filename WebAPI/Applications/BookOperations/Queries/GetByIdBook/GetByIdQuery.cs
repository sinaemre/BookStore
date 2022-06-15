using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Applications.BookOperations.Queries.GetBooks
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _context;
        public int BookId;
        private readonly IMapper _mapper;
        public GetByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).FirstOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı!");

            BookViewModel vm = _mapper.Map<BookViewModel>(book);
            
            return vm;
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; } 
        }
    }
}