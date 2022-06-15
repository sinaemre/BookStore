using FluentValidation;

namespace WebAPI.Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }

    }
}
