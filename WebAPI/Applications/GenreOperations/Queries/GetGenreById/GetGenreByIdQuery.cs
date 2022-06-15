using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Applications.GenreOperations.Queries.GetGenres;
using WebAPI.DbOperations;

namespace WebAPI.Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQuery
    {
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreByIdViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId && x.IsActive);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulumadı!");

            GenreByIdViewModel returnObj = _mapper.Map<GenreByIdViewModel>(genre);

            return returnObj;

        }

    }

    public class GenreByIdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
