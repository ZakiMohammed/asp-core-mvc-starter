using FirstCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext context;

        public BookRepository(BookContext context)
        {
            this.context = context;
        }

        public Book AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public IEnumerable<LanguageCount> BookCountByLanguage()
        {
            return context.Books.GroupBy(g => g.Language).Select(i => new LanguageCount
            {
                Language = i.Key,
                Count = i.Count()
            });
        }

        public Book DeleteBook(int? id)
        {
            var book = context.Books.Find(id);
            context.Books.Remove(book);
            return book;
        }

        public Book GetBook(int? id)
        {
            return context.Books.Find(id);
        }

        public List<Book> GetBooks()
        {
            return context.Books.ToList();
        }
    }
}
