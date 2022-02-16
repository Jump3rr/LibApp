using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(x => x.Genre).ToList();
        }
        public void AddBook(Book book) => _context.Books.Add(book);
        public Book GetBookById(int bookId)
        {
            return _context.Books.Include(x => x.Genre).SingleOrDefault(x => x.Id == bookId);
        }
        public void DeleteBook(int bookId)
        {
            var book = this.GetBookById(bookId);
            _context.Books.Remove(book);
        }
        public void UpdateBook(Book book)
        {
            var bookToUpdate = _context.Books.Find(book.Id);

            bookToUpdate.Name = book.Name;
            bookToUpdate.AuthorName = book.AuthorName;
            bookToUpdate.GenreId = book.GenreId;
            bookToUpdate.ReleaseDate = book.ReleaseDate;
            bookToUpdate.DateAdded = book.DateAdded;
            bookToUpdate.NumberInStock = book.NumberInStock;
        }
        public void Save() => _context.SaveChanges();
    }
}
