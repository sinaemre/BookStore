using FluentValidation;

namespace WebAPI.Applications.AuthorOperations.Queries.GetByIdAuthor
{
    public class GetByIdAuthorQueryValidator : AbstractValidator<GetByIdAuthorQuery>
    {
        public GetByIdAuthorQueryValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
