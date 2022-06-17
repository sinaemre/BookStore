using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Applications.AuthorOperations.Commands.CreateAuthor;
using WebAPI.Applications.AuthorOperations.Commands.DeleteAuthor;
using WebAPI.Applications.AuthorOperations.Commands.UpdateAuthor;
using WebAPI.Applications.AuthorOperations.Queries.GetAuthors;
using WebAPI.Applications.AuthorOperations.Queries.GetByIdAuthor;
using WebAPI.Applications.BookOperations.Commands.CreateBook;
using WebAPI.Applications.BookOperations.Commands.UpdateBook;
using WebAPI.Applications.BookOperations.Queries.GetBooks;
using WebAPI.DbOperations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AuthorViewModel result;
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(_context, _mapper);
            query.AuthorId = id;
            GetByIdAuthorQueryValidator validator = new GetByIdAuthorQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
           
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = updatedAuthor;
            command.AuthorId = id;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

    }
}
