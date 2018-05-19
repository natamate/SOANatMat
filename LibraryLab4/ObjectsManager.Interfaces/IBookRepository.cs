using System.Collections.Generic;
using ObjectsManager.Model;

namespace ObjectsManager.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        int Add(Book book);
        Book Get(int id);
        Book Update(Book book);
        bool Delete(int id);
    }
}
