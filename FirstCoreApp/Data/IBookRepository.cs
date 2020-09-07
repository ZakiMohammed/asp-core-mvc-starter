using FirstCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Data
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBook(int? id);
        Book AddBook(Book book);
        Book DeleteBook(int? id);
        IEnumerable<LanguageCount> BookCountByLanguage();
    }
}
