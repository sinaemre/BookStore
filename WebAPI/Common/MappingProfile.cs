using AutoMapper;
using WebAPI.Applications.BookOperations.Queries.GetBooks;
using WebAPI.Applications.GenreOperations.Queries.GetGenreById;
using WebAPI.Applications.GenreOperations.Queries.GetGenres;
using WebAPI.Entities;
using static WebAPI.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebAPI.Applications.BookOperations.Queries.GetBooks.GetByIdQuery;

namespace WebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreByIdViewModel>();
        }
    }
}