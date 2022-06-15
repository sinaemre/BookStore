using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.Applications.BookOperations.Queries.GetBooks
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);   
        }
    }
}