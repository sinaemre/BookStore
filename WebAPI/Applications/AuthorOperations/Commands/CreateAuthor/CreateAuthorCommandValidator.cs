using FluentValidation;
using System;

namespace WebAPI.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.BookId).GreaterThan(0);
            RuleFor(command => command.Model.Birthday).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
