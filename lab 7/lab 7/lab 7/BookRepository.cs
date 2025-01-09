using System.Collections.Generic;

namespace lab_7
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public List<Book> GetAll()
        {
            return _books;
        }

        public void Create(Book book)
        {
            _books.Add(book);
        }
    }
}
