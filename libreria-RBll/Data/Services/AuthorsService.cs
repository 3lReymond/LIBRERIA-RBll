using libreria_RBll.Data.Models;
using libreria_RBll.Data.ViewModels;
using System;
using System.Linq;

namespace libreria_RBll.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        //metodo para que nos permita agregar un nuevo autor a la BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n=>n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName= n.FullName,
                BookTitles = n.book_Authors.Select(n => n.book.Titulo).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
