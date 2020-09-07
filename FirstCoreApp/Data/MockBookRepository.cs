using FirstCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Data
{
    public class MockBookRepository : IBookRepository
    {
        private static List<Book> books;

        public MockBookRepository()
        {
            books = new List<Book>
            {
                new Book { Id = 1, Title = "Harry Potter 1", Author = "JK Rowling", Description = "Nonumy mazim magna eum duis id dolore tempor vero eirmod sed dolor at aliquyam ullamcorper justo duo duo takimata labore amet nihil eos eirmod elitr sed eu augue nonumy elitr eu ut lorem eos velit ea facilisi lorem justo autem eu stet consectetuer justo et ea invidunt vero amet lorem", Language = Language.English },
                new Book { Id = 2, Title = "IT", Author = "Stephen King", Description = "Iriure doming gubergren exerci tempor quis justo in nobis exerci diam iusto dolor labore velit takimata dolor invidunt dolor vel aliquyam rebum rebum dolor ea lorem ea lorem consequat diam nonumy vel clita invidunt dolore eirmod at voluptua invidunt at erat aliquyam accusam erat tempor consetetur eos autem congue luptatum", Language = Language.German }
            };
        }

        public Book AddBook(Book book)
        {
            book.Id = books.Max(i => i.Id) + 1;
            books.Add(book);
            return book;
        }

        public IEnumerable<LanguageCount> BookCountByLanguage()
        {
            return books.GroupBy(g => g.Language).Select(i => new LanguageCount
            {
                Language = i.Key,
                Count = i.Count()
            });
        }

        public Book DeleteBook(int? id)
        {
            var book = books.Find(i => i.Id == id);
            books.Remove(book);
            return book;
        }

        public Book GetBook(int? id)
        {
            return books.Find(i => i.Id == id);
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
