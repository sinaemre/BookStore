﻿using System;
using System.Linq;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDbContext _context;
        public GenreCreateViewModel Model { get; set; }
        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre is not null)
                throw new InvalidOperationException("Kitap türü zaten mevcut");

            genre = new Genre();
            genre.Name = Model.Name;
            _context.Add(genre);
            _context.SaveChanges();
        }
    }

    public class GenreCreateViewModel
    {
        public string Name { get; set; }
    }
}
