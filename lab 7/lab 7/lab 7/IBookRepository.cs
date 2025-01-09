using System.Collections.Generic;

namespace lab_7
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        void Create(Book book);
    }
}
