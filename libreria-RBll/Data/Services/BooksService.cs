﻿using libreria_RBll.Data.Models;
using libreria_RBll.Data.ViewModels;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace libreria_RBll.Data.Models.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        //metodo para agregar un nuevo libro en la BD
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                ConverUrl = book.ConverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AutorIDs)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }
    //metodo que nos permite obtener la lista de todos los libros de la BD
    public List<Book> GetAllBks() => _context.Books.ToList();
        //Metodo que nos permite obtener el libro que estamos pidiendo de la BD
        public BookWithAuthorsVM GetBookById(int bookid)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.id == bookid).Select(book => new BookWithAuthorsVM()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                ConverUrl = book.ConverUrl,
                PublisherName = book.Publisher.Name,
                AutorNames = book.book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }
        
        //METODO QUE NOS PERMITE MODIFICAR UN LIBRO QUE SE ENCUENTRE EN LA BD
        public Book UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.ConverUrl = book.ConverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        //metodo para eliminar
        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(N => N.id == bookid);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
